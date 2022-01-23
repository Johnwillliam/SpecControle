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
            "Name", "Amount", "VentilatorTypeID", "AirVolume", "PressureTotal", "PressureStatic", "PressureDynamic",
            "RPM", "Efficiency", "ShaftPower", "SoundLevelTypeID", "SoundLevel", "BladeAngle"
        };

        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "Name", "RPM", "BladeAngle"
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

                var airVolume = rows.First(x => x.Cells["Description"].Value.ToString().Equals("AirVolume")).Cells["Value"].Value;
                newCustomOrderVentilator.AirVolume = airVolume == null ? "" : airVolume.ToString();

                var pressureTotal = rows.First(x => x.Cells["Description"].Value.ToString().Equals("PressureTotal")).Cells["Value"].Value;
                newCustomOrderVentilator.PressureTotal = pressureTotal == null ? "" : pressureTotal.ToString();

                var pressureStatic = rows.First(x => x.Cells["Description"].Value.ToString().Equals("PressureStatic")).Cells["Value"].Value;
                newCustomOrderVentilator.PressureStatic = pressureStatic == null ? "" : pressureStatic.ToString();

                var pressureTotals = newCustomOrderVentilator.PressureTotal.Split('/');
                var pressureStatics = newCustomOrderVentilator.PressureStatic.Split('/');
                if (pressureTotals.Length != pressureStatics.Length)
                    return null;

                var result = new string[pressureTotals.Length];
                for (int i = 0; i < pressureTotals.Length; i++)
                {
                    if (!int.TryParse(pressureTotals[i], out int totalPressure) || !int.TryParse(pressureStatics[i], out int staticPressure))
                        return null;

                    result[i] = $"{totalPressure - staticPressure}";
                }
                newCustomOrderVentilator.PressureDynamic = string.Join(" / ", result);

                decimal? q = (decimal)DataHelper.ToNullableInt(newCustomOrderVentilator.AirVolume) / 3600m;
                int? p = DataHelper.ToNullableInt(newCustomOrderVentilator.PressureTotal);
                int r = newCustomOrderVentilator.Efficiency == null ? 1 : (int)newCustomOrderVentilator.Efficiency / 100;
                decimal shaftPower = (decimal)((q == null ? 0 : q) * p / r / 100);
                newCustomOrderVentilator.ShaftPower = $"{shaftPower:0.0000}";

                var efficiency = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Efficiency")).Cells["Value"].Value;
                newCustomOrderVentilator.Efficiency = DataHelper.ToNullableInt(efficiency?.ToString());

                var rpm = rows.First(x => x.Cells["Description"].Value.ToString().Equals("RPM")).Cells["Value"].Value;
                newCustomOrderVentilator.RPM = rpm == null ? "" : rpm.ToString();

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
                if (int.Parse(customOrderVentilator.CustomOrderMotor.RPM) > 0)
                {
                    var rpm = (decimal)(int.Parse(customOrderVentilator.CustomOrderMotor.RPM) / int.Parse(customOrderVentilator.CustomOrderMotor.RPM));
                    customOrderVentilator.RPM = rpm.ToString();
                }
                else
                {
                    customOrderVentilator.RPM = "0";
                }
            }
            else if (customOrderVentilator.CustomOrderMotor.Frequency > 40)
            {
                var value = (decimal)(int.Parse(customOrderVentilator.CustomOrderMotor.RPM) / customOrderVentilator.CustomOrderMotor.Frequency);
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
                customOrderVentilator.Atex = $"{value * customOrderVentilator.CustomOrderMotor.Frequency}";
            }
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

            if (int.Parse(customOrderVentilator.PressureTotal) < int.Parse(customOrderVentilator.PressureDynamic))
            {
                MessageBox.Show("Creation failed. Static pressure can't be higher than the total pressure.");
                return false;
            }

            if (customOrderVentilator.Efficiency > 95)
            {
                MessageBox.Show("Creation failed. Efficiency is to high, value set to 95%.");
                customOrderVentilator.Efficiency = 95;
            }

            if (decimal.Parse(customOrderVentilator.CustomOrderMotor.Power) < decimal.Parse(customOrderVentilator.ShaftPower))
            {
                MessageBox.Show("Creation failed. Motor power is to low.");
                return false;
            }
            else if (decimal.Parse(customOrderVentilator.CustomOrderMotor.Power) < 1.3m * decimal.Parse(customOrderVentilator.ShaftPower))
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