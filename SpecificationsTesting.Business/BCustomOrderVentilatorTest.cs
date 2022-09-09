using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderVentilatorTest
    {
        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "MeasuredVentilatorHighRPM", "MeasuredVentilatorLowRPM", "MeasuredMotorHighRPM", "MeasuredMotorLowRPM", "MeasuredBladeAngle", "Cover",
            "I1High", "I1Low", "I2High", "I2Low", "I3High", "I3Low", "MotorNumber", "Weight", "Date", "UserID", "MotorNumber", "BuildSize"
        };

        public static CustomOrderVentilatorTest Create(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrderVentilatorTests.Add(customOrderVentilatorTest);
                dbContext.SaveChanges();
                return customOrderVentilatorTest;
            }
        }

        public static void Create(CustomOrder customOrder)
        {
            foreach (var ventilator in customOrder.CustomOrderVentilators)
            {
                for (int i = 0; i < ventilator.Amount; i++)
                {
                    Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = ventilator.ID });
                }
            }
        }

        public static void Create(CustomOrderVentilator customOrderVentilator)
        {
            for (int i = 0; i < customOrderVentilator.Amount; i++)
            {
                Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = customOrderVentilator.ID });
            }
        }

        public static void Update(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var toUpdate = dbContext.CustomOrderVentilatorTests.Find(customOrderVentilatorTest.ID);
                if (toUpdate != null)
                {
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilatorTest);
                    dbContext.SaveChanges();
                    Thread.Sleep(300);
                }
            }
        }

        public static bool Validate(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.BladeAngle == null)
            {
                MessageBox.Show("Ventilator blade angle not filled in.");
                //return false;
            }
            if (test.MeasuredBladeAngle == null)
            {
                MessageBox.Show("Measured blade angle not filled in.");
                //return false;
            }
            if (test.CustomOrderVentilator.BladeAngle != null && test.MeasuredBladeAngle != null && test.CustomOrderVentilator.BladeAngle.Value != test.MeasuredBladeAngle.Value)
            {
                MessageBox.Show("Measured blade angle does not correspond the ventilator data. Please check.");
                //return false;
            }
            if (test.MotorNumber == null)
            {
                MessageBox.Show("Motornumber not filled in.");
                //return false;
            }
            if (test.MeasuredMotorHighRPM == null)
            {
                MessageBox.Show("Motor High RPM not filled in.");
                //return false;
            }
            if (test.MeasuredVentilatorHighRPM == null)
            {
                MessageBox.Show("Ventilator High RPM not filled in.");
                //return false;
            }

            return true;
        }

        public static bool ValidateForPrinting(CustomOrderVentilator ventilator)
        {
            foreach (CustomOrderVentilatorTest test in ventilator.CustomOrderVentilatorTests)
            {
                if (!ValidatePrinting(test))
                    return false;
            }
            return true;
        }

        public static bool ValidatePrinting(CustomOrderVentilatorTest test)
        {
            var validationMessage = $"Test ID {test.ID}: {ValidateForPrinting(test)}";
            if (string.IsNullOrEmpty(validationMessage))
            {
                return true;
            }
            MessageBox.Show(validationMessage);
            return false;
        }

        public static string ValidateForPrinting(CustomOrderVentilatorTest test)
        {
            if (test.MeasuredBladeAngle == null)
            {
                return "Measured blade angle not filled in.";
            }
            if (test.MeasuredBladeAngle != test.CustomOrderVentilator.BladeAngle)
            {
                return "Measured blade angle does not matched the ordered angle.";
            }
            if (test.I1High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I2High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I3High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage)
            {
                return "One of the measured amperages is higher than the nominal amperage.";
            }
            if(test.CustomOrderVentilator.CustomOrderMotor.HighAmperage != null && test.CustomOrderVentilator.CustomOrderMotor.LowAmperage != null)
            {
                var iLows = new List<decimal?>() { test.I1Low, test.I2Low, test.I3Low };
                var iHighs = new List<decimal?>() { test.I1High, test.I2High, test.I3High };
                var max = iHighs.Max();
                var min = iLows.Min();
                var difference = (decimal)(max / min);
                if (max != null && min != null && difference > 1.1m)
                {
                    MessageBox.Show($"Test ID {test.ID}: The difference between the highest and lowest amperage is more than 10%.");
                }
            }
            if (test.CustomOrderVentilator.CustomOrderMotor.HighRPM == null)
            {
                return "Motor high RPM is not filled in.";
            }
            if (test.CustomOrderVentilator.HighRPM == null)
            {
                return "Ventilator high RPM is not filled in.";
            }
            if (test.MeasuredMotorHighRPM == null)
            {
                return "Measured motor high not filled in.";
            }
            if (test.MeasuredMotorHighRPM < test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                return "The measured motor RPM is lower than the nominal RPM.";
            }
            if (test.MeasuredMotorHighRPM < test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                return "The measured motor RPM is lower t han the nominal RPM.";
            }
            if (test.MeasuredMotorHighRPM != null && test.CustomOrderVentilator.CustomOrderMotor.Frequency != null)
            {
                var syncRPM = CalculateSyncRPM(test.MeasuredMotorHighRPM.Value, test.CustomOrderVentilator.CustomOrderMotor.Frequency.Value);
                if (test.MeasuredMotorHighRPM > syncRPM)
                {
                    return $"Measured motor high RPM ({test.MeasuredMotorHighRPM}) is higher than the synchronous rpm ({syncRPM}). This is not possible.";
                }
                if (test.MeasuredVentilatorHighRPM > test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
                {
                    return $"Measured ventilator high RPM ({test.MeasuredVentilatorHighRPM}) is higher than the motor RPM ({test.CustomOrderVentilator.CustomOrderMotor.HighRPM}), wrong motor?";
                }
            }
            if (test.MeasuredMotorLowRPM != null && test.CustomOrderVentilator.CustomOrderMotor.Frequency != null)
            {
                var syncRPM = CalculateSyncRPM(test.MeasuredMotorLowRPM.Value, test.CustomOrderVentilator.CustomOrderMotor.Frequency.Value);
                if (test.MeasuredMotorLowRPM > syncRPM)
                {
                    return $"Measured motor low RPM ({test.MeasuredMotorLowRPM}) is higher than the synchronous rpm ({syncRPM}). This is not possible.";
                }
                if (test.MeasuredVentilatorHighRPM > test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
                {
                    return $"Measured ventilator high RPM ({test.MeasuredVentilatorHighRPM}) is higher than the motor RPM ({test.CustomOrderVentilator.CustomOrderMotor.HighRPM}), wrong motor?";
                }
            }
            if (MeasuredVentilatorRPMIsInSpec(test.CustomOrderVentilator.CustomOrderMotor.HighRPM, test.CustomOrderVentilator.HighRPM, test.MeasuredMotorHighRPM, test.MeasuredVentilatorHighRPM))
            {
                return "The measured ventilator high RPM differs more than 3%.";
            }
            return string.Empty;
        }

        public static bool MeasuredVentilatorRPMIsInSpec(int? customOrderMotorHighRPM, int? customOrderVentilatorHighRPM, int? measuredMotorHighRPM, int? measuredVentilatorHighRPM)
        {
            var nv = measuredMotorHighRPM / customOrderMotorHighRPM * customOrderVentilatorHighRPM;
            return Math.Max((double)customOrderVentilatorHighRPM, (double)measuredVentilatorHighRPM) / Math.Min((double)nv, (double)measuredVentilatorHighRPM) > 1.03;
        }

        public static int CalculateSyncRPM(int measuredMotorHighRPM, int frequency)
        {
            var syncRPM = (double)measuredMotorHighRPM / (double)frequency;

            switch (syncRPM)
            {
                case double n when (n <= 10):
                    return frequency * 10;
                case double n when (n <= 15):
                    return frequency * 15;
                case double n when (n <= 20):
                    return frequency * 20;
                case double n when (n <= 30):
                    return frequency * 30;
                case double n when (n <= 60):
                    return frequency * 60;
            }
            return 0;
        }

        public static CustomOrderVentilatorTest CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderVentilatorTest = new CustomOrderVentilatorTest();

                var measuredVentilatorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorHighRPM = DataHelper.ToNullableInt(measuredVentilatorHighRPM?.ToString());

                var measuredVentilatorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorLowRPM = DataHelper.ToNullableInt(measuredVentilatorLowRPM?.ToString());

                var measuredBladeAngle = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredBladeAngle")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredBladeAngle = DataHelper.ToNullableInt(measuredBladeAngle?.ToString());

                var measuredMotorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorHighRPM = DataHelper.ToNullableInt(measuredMotorHighRPM?.ToString());

                var measuredMotorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorLowRPM = DataHelper.ToNullableInt(measuredMotorLowRPM?.ToString());

                var cover = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Cover")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Cover = DataHelper.ToNullableInt(cover?.ToString());

                var i1High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I1High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I1High = DataHelper.ToNullableDecimal(i1High?.ToString());

                var i1Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I1Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I1Low = DataHelper.ToNullableDecimal(i1Low?.ToString());

                var i2High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2High = DataHelper.ToNullableDecimal(i2High?.ToString());

                var i2Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2Low = DataHelper.ToNullableDecimal(i2Low?.ToString());

                var i3High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3High = DataHelper.ToNullableDecimal(i3High?.ToString());

                var i3Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3Low = DataHelper.ToNullableDecimal(i3Low?.ToString());

                var motorNumber = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MotorNumber")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MotorNumber = motorNumber?.ToString();

                var weight = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Weight")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Weight = DataHelper.ToNullableInt(weight?.ToString());

                var date = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Date")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Date = string.IsNullOrEmpty(date.ToString()) ? (DateTime?)null : DateTime.Parse(date.ToString());

                var buildSize = rows.First(x => x.Cells["Description"].Value.ToString().Equals("BuildSize")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.BuildSize = DataHelper.ToNullableInt(buildSize?.ToString());

                newCustomOrderVentilatorTest.I2High = newCustomOrderVentilatorTest.I2High ?? newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I3High = newCustomOrderVentilatorTest.I3High ?? newCustomOrderVentilatorTest.I1High;

                newCustomOrderVentilatorTest.I2Low = newCustomOrderVentilatorTest.I2Low ?? newCustomOrderVentilatorTest.I1Low;
                newCustomOrderVentilatorTest.I3Low = newCustomOrderVentilatorTest.I3Low ?? newCustomOrderVentilatorTest.I1Low;

                return newCustomOrderVentilatorTest;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
