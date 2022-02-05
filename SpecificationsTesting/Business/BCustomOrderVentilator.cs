using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;
using System.Data.Entity.Migrations;
using System.Threading;
using System.Windows.Forms;
using System.Data.Entity;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderVentilator
    {
        public static List<string> OrderDisplayPropertyNames = new List<string>
        {
            "Name", "Amount", "VentilatorTypeID", "HighAirVolume", "LowAirVolume", "HighPressureTotal", "LowPressureTotal", "HighPressureStatic", "LowPressureStatic", "HighPressureDynamic", "LowPressureDynamic",
            "HighRPM", "LowRPM", "Efficiency", "HighShaftPower", "LowShaftPower", "SoundLevelTypeID", "SoundLevel", "BladeAngle"
        };

        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "Name", "HighRPM", "LowRPM", "BladeAngle"
        };

        public static List<string> ConfigurationDisplayPropertyNames = new List<string>
        {
            "Atex", "GroupTypeID", "TemperatureClassID", "CatID", "CatOutID"
        };

        public static CustomOrderVentilator Create(CustomOrderVentilator customOrderVentilator)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrderVentilators.Add(customOrderVentilator);
                dbContext.SaveChanges();
            }
            
            BCustomOrderVentilatorTest.Create(customOrderVentilator);
            return customOrderVentilator;
        }

        public static void Update(CustomOrderVentilator customOrderVentilator)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var toUpdate = dbContext.CustomOrderVentilators.Find(customOrderVentilator.ID);
                if (toUpdate != null)
                {
                    customOrderVentilator.CustomOrderID = toUpdate.CustomOrderID;
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilator);
                    dbContext.SaveChanges();
                }
            }
        }

        public static void DeleteById(int id)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var customOrderVentilator = dbContext.CustomOrderVentilators.Find(id);
                if (customOrderVentilator != null)
                {
                    foreach (CustomOrderVentilatorTest test in dbContext.CustomOrderVentilatorTests.Where(x => x.CustomOrderVentilatorID == customOrderVentilator.ID))
                    {
                        dbContext.CustomOrderVentilatorTests.Remove(test);
                    }
                    dbContext.CustomOrderVentilators.Remove(customOrderVentilator);
                    dbContext.SaveChanges();
                }
            }
        }

        public static CustomOrderVentilator CreateObject(CustomOrderVentilator newCustomOrderVentilator, List<DataGridViewRow> rows)
        {
            try
            {
                var amount = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Amount")).Cells["Value"].Value;
                if (!int.TryParse(amount?.ToString(), out int value))
                    return null;

                newCustomOrderVentilator.Amount = value;

                var name = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Name")).Cells["Value"].Value;
                newCustomOrderVentilator.Name = name.ToString();

                var highAirVolume = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighAirVolume")).Cells["Value"].Value;
                newCustomOrderVentilator.HighAirVolume = DataHelper.ToNullableInt(highAirVolume?.ToString());

                var lowAirVolume = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowAirVolume")).Cells["Value"].Value;
                newCustomOrderVentilator.LowAirVolume = DataHelper.ToNullableInt(lowAirVolume?.ToString());

                var highPressureTotal = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighPressureTotal")).Cells["Value"].Value;
                newCustomOrderVentilator.HighPressureTotal = DataHelper.ToNullableInt(highPressureTotal?.ToString());

                var lowPressureTotal = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureTotal")).Cells["Value"].Value;
                newCustomOrderVentilator.LowPressureTotal = DataHelper.ToNullableInt(lowPressureTotal?.ToString());

                var highPressureStatic = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighPressureStatic")).Cells["Value"].Value;
                newCustomOrderVentilator.HighPressureStatic = DataHelper.ToNullableInt(highPressureStatic?.ToString());

                var lowPressureStatic = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowPressureStatic")).Cells["Value"].Value;
                newCustomOrderVentilator.LowPressureStatic = DataHelper.ToNullableInt(lowPressureStatic?.ToString());

                newCustomOrderVentilator.HighPressureDynamic = newCustomOrderVentilator.HighPressureTotal - newCustomOrderVentilator.HighPressureStatic;
                newCustomOrderVentilator.LowPressureDynamic = newCustomOrderVentilator.LowPressureTotal - newCustomOrderVentilator.LowPressureStatic;

                decimal? q = (decimal)newCustomOrderVentilator.HighAirVolume / 3600m;
                int? p = newCustomOrderVentilator.HighPressureTotal;
                int r = newCustomOrderVentilator.Efficiency == null ? 1 : (int)newCustomOrderVentilator.Efficiency / 100;
                decimal shaftPower = (decimal)((q == null ? 0 : q) * p / r / 100);
                newCustomOrderVentilator.HighShaftPower = shaftPower;

                q = (decimal)newCustomOrderVentilator.LowAirVolume / 3600m;
                p = newCustomOrderVentilator.LowPressureTotal;
                shaftPower = (decimal)((q == null ? 0 : q) * p / r / 100);
                newCustomOrderVentilator.LowShaftPower = shaftPower;

                var efficiency = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Efficiency")).Cells["Value"].Value;
                newCustomOrderVentilator.Efficiency = DataHelper.ToNullableInt(efficiency?.ToString());

                var highRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighRPM")).Cells["Value"].Value;
                newCustomOrderVentilator.HighRPM = DataHelper.ToNullableInt(highRPM?.ToString());

                var lowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowRPM")).Cells["Value"].Value;
                newCustomOrderVentilator.LowRPM = DataHelper.ToNullableInt(lowRPM?.ToString());

                var soundLevel = rows.First(x => x.Cells["Description"].Value.ToString().Equals("SoundLevel")).Cells["Value"].Value;
                newCustomOrderVentilator.SoundLevel = DataHelper.ToNullableInt(soundLevel?.ToString());

                var bladeAngle = rows.First(x => x.Cells["Description"].Value.ToString().Equals("BladeAngle")).Cells["Value"].Value;
                newCustomOrderVentilator.BladeAngle = DataHelper.ToNullableInt(bladeAngle?.ToString());

                return newCustomOrderVentilator;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Calculate(CustomOrderVentilator customOrderVentilator)
        {
            if (customOrderVentilator == null)
            {
                MessageBox.Show("Calculation failed. Please check the filled in data of the ventilator.");
                return;
            }

            if (customOrderVentilator.CustomOrderMotor == null)
            {
                MessageBox.Show("Calculation failed. Please check the filled in data of the motor.");
                return;
            }

            var dbContext = new SpecificationsDatabaseModel();
            if (customOrderVentilator.VentilatorType == null)
                customOrderVentilator.VentilatorType = dbContext.VentilatorTypes.Find(customOrderVentilator.VentilatorTypeID);

            if (customOrderVentilator.VentilatorType.Description.ToUpper().Contains("V-BELT"))
            {
                if (customOrderVentilator.CustomOrderMotor.HighRPM > 0)
                {
                    var rpm = (customOrderVentilator.CustomOrderMotor.HighRPM / customOrderVentilator.CustomOrderMotor.HighRPM);
                    customOrderVentilator.HighRPM = rpm;
                }
                else
                {
                    customOrderVentilator.HighRPM = 0;
                }
                if (customOrderVentilator.CustomOrderMotor.LowRPM > 0)
                {
                    var rpm = (customOrderVentilator.CustomOrderMotor.LowRPM / customOrderVentilator.CustomOrderMotor.LowRPM);
                    customOrderVentilator.LowRPM = rpm;
                }
                else
                {
                    customOrderVentilator.LowRPM = 0;
                }
            }
            if (customOrderVentilator.CustomOrderMotor.Frequency > 40)
            {
                var value = (decimal)(customOrderVentilator.CustomOrderMotor.HighRPM / customOrderVentilator.CustomOrderMotor.Frequency);
                value = CalculateAtexValue(value);
                customOrderVentilator.Atex = $"{value * customOrderVentilator.CustomOrderMotor.Frequency}";
            }
        }

        private static decimal CalculateAtexValue(decimal value)
        {
            switch (value)
            {
                case decimal n when (n >= 5 && n <= 7.5m):
                    value = 7.5m;
                    break;
                case decimal n when (n >= 7.5m && n <= 10):
                    value = 10;
                    break;
                case decimal n when (n >= 10 && n <= 15):
                    value = 15;
                    break;
                case decimal n when (n >= 15 && n <= 30):
                    value = 30;
                    break;
                case decimal n when (n >= 30 && n <= 60):
                    value = 60;
                    break;
                default:
                    break;
            }
            return value;
        }

        public static int CalculateSyncRPM(int rpm, int frequency)
        {
            switch (frequency)
            {
                case 50:
                    switch (rpm)
                    {
                        case int n when (n > 1600):
                            return 3000;
                        case int n when (n > 1100):
                            return 1500;
                        case int n when (n > 755):
                            return 1000;
                        case int n when (n > 505):
                            return 750;
                        default:
                            return 500;
                    }
                case 60:
                    switch (rpm)
                    {
                        case int n when (n > 1900):
                            return 3600;
                        case int n when (n > 1300):
                            return 1800;
                        case int n when (n > 906):
                            return 1200;
                        case int n when (n > 605):
                            return 900;
                        default:
                            return 600;
                    }
                default:
                    break;
            }
            return 0;
        }

        public static bool Validate(CustomOrderVentilator customOrderVentilator)
        {
            if (customOrderVentilator == null)
            {
                MessageBox.Show("Creation failed. Please check the filled in data of the ventilator.");
                return false;
            }

            if (customOrderVentilator.CustomOrderMotor == null)
            {
                MessageBox.Show("Creation failed. Please check the filled in data of the motor.");
                return false;
            }

            if (customOrderVentilator.HighPressureTotal < customOrderVentilator.HighPressureDynamic || customOrderVentilator.LowPressureTotal < customOrderVentilator.LowPressureDynamic)
            {
                MessageBox.Show("Creation failed. Static pressure can't be higher than the total pressure.");
                return false;
            }

            if (customOrderVentilator.Efficiency > 95)
            {
                MessageBox.Show("Creation failed. Efficiency is to high, value set to 95%.");
                customOrderVentilator.Efficiency = 95;
            }

            if (customOrderVentilator.CustomOrderMotor.HighPower < customOrderVentilator.HighShaftPower || customOrderVentilator.CustomOrderMotor.LowPower < customOrderVentilator.LowShaftPower)
            {
                MessageBox.Show("Creation failed. Motor power is to low.");
                return false;
            }
            else if (customOrderVentilator.CustomOrderMotor.HighPower < 1.3m * customOrderVentilator.HighShaftPower || customOrderVentilator.CustomOrderMotor.LowPower < 1.3m * customOrderVentilator.LowShaftPower)
            {
                DialogResult dialogResult = MessageBox.Show("Motor power is lower than 1.3 x the nominal power. Continue?", "Motor Power", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }

            return true;
        }

    }
}