using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderVentilatorTest
    {
        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "MeasuredVentilatorHighRPM", "MeasuredVentilatorLowRPM", "MeasuredMotorHighRPM", "MeasuredMotorLowRPM", "MeasuredBladeAngle", "Cover",
            "I1High", "I1Low", "I2High", "I2Low", "I3High", "I3Low", "MotorNumber", "Weight", "Date", "UserID"
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
                    BCustomOrderVentilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = ventilator.ID });
                }
            }
        }

        public static void Create(CustomOrderVentilator customOrderVentilator)
        {
            for (int i = 0; i < customOrderVentilator.Amount; i++)
            {
                BCustomOrderVentilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = customOrderVentilator.ID });
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
                if (!BCustomOrderVentilatorTest.ValidateForPrinting(test))
                    return false;
            }
            return true;
        }

        public static bool ValidateForPrinting(CustomOrderVentilatorTest test)
        {
            if (test.MeasuredBladeAngle == null)
            {
                MessageBox.Show($"Test ID {test.ID}: Measured blade angle not filled in.");
                return false;
            }
            if (test.MeasuredBladeAngle != test.CustomOrderVentilator.BladeAngle)
            {
                MessageBox.Show($"Test ID {test.ID}: Measured blade angle does not matched the ordered angle.");
                return false;
            }
            if (test.I1High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I2High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I3High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage)
            {
                MessageBox.Show($"Test ID {test.ID}: One of the measured amperages is higher than the nominal amperage.");
                return false;
            }
            if (test.I1Low < (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage / 2) || test.I2Low < (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage / 2) || test.I3Low < (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage / 2))
            {
                MessageBox.Show($"Test ID {test.ID}: One of the measured amperages is lower than 50% of the nominal amperage.");
                return false;
            }
            var iLows = new List<int?>() { test.I1Low, test.I2Low, test.I3Low };
            var iHighs = new List<int?>() { test.I1High, test.I2High, test.I3High };
            if ((double)(iHighs.Max() / iLows.Min()) > 1.1)
            {
                MessageBox.Show($"Test ID {test.ID}: The difference between the highest and lowest amperage is more than 10%.");
                return false;
            }
            if (test.CustomOrderVentilator.CustomOrderMotor.HighRPM == null)
            {
                MessageBox.Show($"Test ID {test.ID}: Motor high RPM is not filled in.");
                return false;
            }
            if (test.CustomOrderVentilator.HighRPM == null)
            {
                MessageBox.Show($"Test ID {test.ID}: Ventilator high RPM is not filled in.");
                return false;
            }
            if (test.MeasuredMotorHighRPM == null)
            {
                MessageBox.Show($"Test ID {test.ID}: Measured motor high not filled in.");
                return false;
            }
            if (test.MeasuredMotorHighRPM < test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                MessageBox.Show($"Test ID {test.ID}: The measured motor RPM is lower t han the nominal RPM.");
                return false;
            }
            if (test.MeasuredMotorHighRPM < test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                MessageBox.Show($"Test ID {test.ID}: The measured motor RPM is lower t han the nominal RPM.");
                return false;
            }
            if (test.MeasuredVentilatorHighRPM != null && test.CustomOrderVentilator.CustomOrderMotor.Frequency != null)
            {
                var syncRPM = BCustomOrderVentilator.CalculateSyncRPM(test.MeasuredVentilatorHighRPM.Value, test.CustomOrderVentilator.CustomOrderMotor.Frequency.Value);
                if (test.MeasuredVentilatorHighRPM > test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
                {
                    MessageBox.Show($"Test ID {test.ID}: Measured motor RPM is higher than possible, wrong motor?");
                    return false;
                }
            }
            var r1 = test.CustomOrderVentilator.CustomOrderMotor.HighRPM / test.CustomOrderVentilator.HighRPM;
            var r2 = test.MeasuredMotorHighRPM / test.MeasuredVentilatorHighRPM;
            if (r1 != r2 && (double)(r1 / r2) < 0.95)
            {
                MessageBox.Show($"Test ID {test.ID}: The measured ventilator RPM differs more than 5%.");
                return false;
            }
            return true;
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
                newCustomOrderVentilatorTest.I1High = DataHelper.ToNullableInt(i1High?.ToString());

                var i1Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I1Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I1Low = DataHelper.ToNullableInt(i1Low?.ToString());

                var i2High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2High = DataHelper.ToNullableInt(i2High?.ToString());

                var i2Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2Low = DataHelper.ToNullableInt(i2Low?.ToString());

                var i3High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3High = DataHelper.ToNullableInt(i3High?.ToString());

                var i3Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3Low = DataHelper.ToNullableInt(i3Low?.ToString());

                var motorNumber = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MotorNumber")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MotorNumber = DataHelper.ToNullableInt(motorNumber?.ToString());

                var weight = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Weight")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Weight = DataHelper.ToNullableInt(weight?.ToString());

                var date = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Date")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Date = string.IsNullOrEmpty(date.ToString()) ? (DateTime?)null : DateTime.Parse(date.ToString());


                return newCustomOrderVentilatorTest;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
