using EntityFrameworkModelV2.Models;
using EntityFrameworkModelV2.Context;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using EntityFrameworkModelV2.Extensions;

namespace Logic.Business
{
    public static class BCustomOrderVentilator
    {
        private static readonly List<string> _orderDisplayPropertyNames = new List<string>
        {
            "Name", "Amount", "VentilatorTypeID", "HighAirVolume", "LowAirVolume", "HighPressureTotal", "LowPressureTotal", "HighPressureStatic", "LowPressureStatic", "HighPressureDynamic", "LowPressureDynamic",
            "HighRPM", "LowRPM", "Efficiency", "HighShaftPower", "LowShaftPower", "SoundLevelTypeID", "SoundLevel", "BladeAngle"
        };

        private static readonly List<string> _controleDisplayPropertyNames = new List<string>
        {
            "Name", "HighRPM", "LowRPM", "BladeAngle"
        };

        private static readonly List<string> _configurationDisplayPropertyNames = new List<string>
        {
            "Atex", "GroupTypeID", "TemperatureClassID", "CatID", "CatOutID"
        };

        public static List<string> OrderDisplayPropertyNames => _orderDisplayPropertyNames;

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static List<string> ConfigurationDisplayPropertyNames => _configurationDisplayPropertyNames;

        public static CustomOrderVentilator GetById(int id)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                return dbContext.CustomOrderVentilators.Include(x => x.CustomOrderMotor).Include(x => x.CustomOrderVentilatorTests).Include(x => x.TemperatureClass).FirstOrDefault(x => x.ID == id);
            }
        }

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
                    var tests = dbContext.CustomOrderVentilatorTests.Where(x => x.CustomOrderVentilatorID == customOrderVentilator.ID).ToList();
                    if (customOrderVentilator.Amount < toUpdate.Amount && tests.Count > 1)
                    {
                        var difference = toUpdate.Amount - customOrderVentilator.Amount;
                        for (int i = 0; i < difference; i++)
                        {
                            var lastTest = tests.Last();
                            customOrderVentilator.CustomOrderVentilatorTests.Remove(lastTest);
                            dbContext.CustomOrderVentilatorTests.Remove(lastTest);
                        }
                    }
                    else if (customOrderVentilator.Amount > toUpdate.Amount)
                    {
                        var difference = customOrderVentilator.Amount - toUpdate.Amount;
                        for (int i = 0; i < difference; i++)
                        {
                            var newTest = new CustomOrderVentilatorTest() { CustomOrderVentilatorID = customOrderVentilator.ID };
                            dbContext.CustomOrderVentilatorTests.Add(newTest);
                        }
                    }

                    customOrderVentilator.CustomOrderID = toUpdate.CustomOrderID;
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilator);
                    dbContext.SaveChanges();
                }
            }
        }

        public static CustomOrderVentilator Copy(CustomOrderVentilator toCopy)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var entity = dbContext.CustomOrderVentilators
                          .AsNoTracking()
                          .Include(x => x.CustomOrderMotor)
                          .Single(x => x.ID == toCopy.ID);

                entity.ID = 0;
                entity.CustomOrderMotor.ID = 0;
                return Create(entity);
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
                    var motor = dbContext.CustomOrderMotors.Find(customOrderVentilator.CustomOrderMotorID);
                    dbContext.CustomOrderMotors.Remove(motor);
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
                if (int.TryParse(amount?.ToString(), out int value))
                {
                    newCustomOrderVentilator.Amount = value;
                }

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

        public static decimal? CalculateShaftPower(decimal airVolume, int? pressureTotal, int? efficiency)
        {
            int press = pressureTotal == null ? 1 : (int)pressureTotal;
            decimal eff = efficiency == null ? 1 : (decimal)efficiency / 100;
            return airVolume * press / 3600 / (eff * 10) / 100;
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

            if (customOrderVentilator.HighAirVolume != null)
            {
                customOrderVentilator.HighShaftPower = CalculateShaftPower((decimal)customOrderVentilator.HighAirVolume,
                    customOrderVentilator.HighPressureTotal,
                    customOrderVentilator.Efficiency);
            }

            if (customOrderVentilator.LowAirVolume != null)
            {
                customOrderVentilator.LowShaftPower = CalculateShaftPower((decimal)customOrderVentilator.LowAirVolume,
                    customOrderVentilator.LowPressureTotal,
                    customOrderVentilator.Efficiency);
            }

            var motorConstant = CalculateMotorConstant(customOrderVentilator.CustomOrderMotor.LowRPM, customOrderVentilator.CustomOrderMotor.HighRPM);
            customOrderVentilator.LowAirVolume = CalculateLowAirVolume(motorConstant, customOrderVentilator.HighAirVolume);
            customOrderVentilator.LowPressureTotal = CalculateLowPressureTotal(motorConstant, customOrderVentilator.HighPressureTotal);
            customOrderVentilator.LowPressureStatic = CalculateLowPressureStatic(motorConstant, customOrderVentilator.HighPressureStatic);
            customOrderVentilator.LowShaftPower = CalculateLowShaftPower(motorConstant, customOrderVentilator.HighShaftPower);
            customOrderVentilator.LowRPM = customOrderVentilator.CustomOrderMotor.LowRPM;

            customOrderVentilator.HighPressureDynamic = customOrderVentilator.HighPressureTotal - customOrderVentilator.HighPressureStatic;
            customOrderVentilator.LowPressureDynamic = customOrderVentilator.LowPressureTotal - customOrderVentilator.LowPressureStatic;

            if (customOrderVentilator.VentilatorType == null && customOrderVentilator.VentilatorTypeID != null)
            {
                customOrderVentilator.VentilatorType = new SpecificationsDatabaseModel().VentilatorTypes.FirstOrDefault(x => x.ID == customOrderVentilator.VentilatorTypeID);
            }

            if (customOrderVentilator.VentilatorType != null && !customOrderVentilator.IsDirectBelt())
            {
                if (customOrderVentilator.CustomOrderMotor.LowRPM > 0)
                {
                    customOrderVentilator.LowRPM = CalculateVBeltLowRPM(motorConstant, (int)customOrderVentilator.HighRPM);
                }
                else
                {
                    customOrderVentilator.LowRPM = 0;
                }
            }
            if (customOrderVentilator.CustomOrderMotor.Frequency > 40)
            {
                customOrderVentilator.Atex = CalculateAtexValue(customOrderVentilator.CustomOrderMotor.HighRPM, customOrderVentilator.CustomOrderMotor.Frequency).ToString();
            }
        }

        public static int CalculateVBeltLowRPM(double motorConstant, int? highRPM)
        {
            return (int)Math.Round(motorConstant * (int)highRPM);
        }

        public static double CalculateMotorConstant(int? motorLowRpm, int? motorHighRPM)
        {
            return motorLowRpm == null ? 0 : (double)motorLowRpm / (double)motorHighRPM;
        }

        public static decimal? CalculateLowShaftPower(double motorConstant, decimal? highShaftPower)
        {
            return motorConstant != 0 ? (decimal?)Math.Round(Math.Pow(motorConstant, 3) * (double)highShaftPower, 2) : null;
        }

        public static int? CalculateLowPressureStatic(double motorConstant, int? highPressureStatic)
        {
            return motorConstant != 0 ? (int?)Math.Ceiling((decimal)(Math.Pow(motorConstant, 2) * highPressureStatic)) : null;
        }

        public static int? CalculateLowAirVolume(double motorConstant, int? highAirVolume)
        {
            return motorConstant != 0 ? (int?)(motorConstant * highAirVolume) : null;
        }

        public static int? CalculateLowPressureTotal(double motorConstant, int? highPressureTotal)
        {
            if (motorConstant == 0)
            {
                return null;
            }
            var result = Math.Pow(motorConstant, 2) * highPressureTotal;
            return (int)Math.Ceiling((double)result);
        }

        public static decimal CalculateAtexValue(int? highRPM, int? frequency)
        {
            var value = (decimal)(highRPM / frequency);
            switch (value)
            {
                case decimal n when n >= 5 && n <= 7.5m:
                    value = 7.5m;
                    break;
                case decimal n when n >= 7.5m && n <= 10:
                    value = 10;
                    break;
                case decimal n when n >= 10 && n <= 15:
                    value = 15;
                    break;
                case decimal n when n >= 15 && n <= 30:
                    value = 30;
                    break;
                case decimal n when n >= 30 && n <= 60:
                    value = 60;
                    break;
                default:
                    break;
            }
            return value * (int)frequency;
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

            if (customOrderVentilator.CustomOrderMotor.HighPower < 1.3m * customOrderVentilator.HighShaftPower || customOrderVentilator.CustomOrderMotor.LowPower < 1.3m * customOrderVentilator.LowShaftPower)
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