using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Extensions;
using EntityFrameworkModelV2.Models;

namespace Logic.Business
{
    public static class BCustomOrderVentilatorTest
    {
        private static readonly List<string> _controleDisplayPropertyNames = new List<string>
        {
            "MeasuredVentilatorHighRPM", "MeasuredVentilatorLowRPM", "MeasuredMotorHighRPM", "MeasuredMotorLowRPM", "MeasuredBladeAngle", "Cover",
            "I1High", "I1Low", "I2High", "I2Low", "I3High", "I3Low", "MotorNumber", "Weight", "Date", "UserID", "MotorNumber", "BuildSize"
        };

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static CustomOrderVentilatorTest Create(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrderVentilatorTests.Add(customOrderVentilatorTest);
                dbContext.SaveChanges();
                return customOrderVentilatorTest;
            }
        }

        public static CustomOrderVentilatorTest GetByID(int id)
        {
            var dbContext = new SpecificationsDatabaseModel();
            dbContext.SaveChanges();
            return dbContext.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == id);
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

        private static string CheckNullableProperties(CustomOrderVentilatorTest test)
        {
            if (test.MeasuredBladeAngle == null)
            {
                return "Measured blade angle not filled in.";
            }
            if (test.MeasuredVentilatorHighRPM == null)
            {
                return "Measured ventilator high RPM not filled in.";
            }
            //if (test.MeasuredVentilatorLowRPM == null)
            //{
            //    return "Measured ventilator low RPM not filled in.";
            //}
            if (test.MeasuredMotorHighRPM == null)
            {
                return "Measured motor high RPM not filled in.";
            }
            //if (test.MeasuredMotorLowRPM == null)
            //{
            //    return "Measured motor low RPM not filled in.";
            //}
            test.CustomOrderVentilator = BCustomOrderVentilator.GetById(test.CustomOrderVentilatorID);
            if (test.CustomOrderVentilator.CustomOrderMotor == null)
            {
                return "No motor found, please check configuration.";
            }
            if (test.CustomOrderVentilator.CustomOrderMotor.HighRPM == null)
            {
                return "Motor high RPM is not filled in.";
            }
            if (test.CustomOrderVentilator.HighRPM == null)
            {
                return "Ventilator high RPM is not filled in.";
            }
            return null;
        }

        private static string ValidateSyncRPM(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.CustomOrderMotor.Frequency.HasValue)
            {
                var syncRPM = CalculateSyncRPM(test.MeasuredMotorHighRPM.Value, test.CustomOrderVentilator.CustomOrderMotor.Frequency.Value);
                if (test.MeasuredMotorHighRPM > syncRPM)
                {
                    return $"Measured motor high RPM ({test.MeasuredMotorHighRPM}) is higher than the synchronous rpm ({syncRPM}). This is not possible.";
                }

                if (test.MeasuredMotorLowRPM.HasValue)
                {
                    syncRPM = CalculateSyncRPM(test.MeasuredMotorLowRPM.Value, test.CustomOrderVentilator.CustomOrderMotor.Frequency.Value);
                    if (test.MeasuredMotorLowRPM > syncRPM)
                    {
                        return $"Measured motor low RPM ({test.MeasuredMotorLowRPM}) is higher than the synchronous rpm ({syncRPM}). This is not possible.";
                    }
                }
            }
            return null;
        }

        public static string ValidateForPrinting(CustomOrderVentilatorTest test)
        {
            var nullablePropertiesChecked = CheckNullableProperties(test);
            if (!string.IsNullOrEmpty(nullablePropertiesChecked))
            {
                return nullablePropertiesChecked;
            }
            if (test.MeasuredBladeAngle != test.CustomOrderVentilator.BladeAngle)
            {
                return "Measured blade angle does not matched the ordered angle.";
            }
            if (test.I1High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I2High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I3High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage)
            {
                return "One of the measured amperages is higher than the nominal amperage.";
            }
            var syncRPMChecked = ValidateSyncRPM(test);
            if (!string.IsNullOrEmpty(syncRPMChecked))
            {
                return syncRPMChecked;
            }
            if (test.MeasuredMotorHighRPM < test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                return "The measured motor RPM is lower than the nominal RPM.";
            }
            if (test.MeasuredVentilatorHighRPM > test.CustomOrderVentilator.CustomOrderMotor.HighRPM)
            {
                var percentage = test.CustomOrderVentilator.IsDirectBelt() ? 8 : 3;
                if (!MeasuredVentilatorRPMIsInSpec(test.CustomOrderVentilator.CustomOrderMotor.HighRPM, test.CustomOrderVentilator.HighRPM, test.MeasuredMotorHighRPM, test.MeasuredVentilatorHighRPM, percentage))
                {
                    return $"The measured ventilator high RPM differs more than {percentage}%.";
                }
            }
            return string.Empty;
        }

        public static bool MeasuredVentilatorRPMIsInSpec(int? customOrderMotorHighRPM, int? customOrderVentilatorHighRPM, int? measuredMotorHighRPM, int? measuredVentilatorHighRPM, int percentage)
        {
            var nv = measuredMotorHighRPM / customOrderMotorHighRPM * customOrderVentilatorHighRPM;
            var max = Math.Max((double)customOrderVentilatorHighRPM, (double)measuredVentilatorHighRPM);
            var min = Math.Min((double)nv, (double)measuredVentilatorHighRPM);
            var calc = max / min;
            var perc = ((double)percentage / (double)100) + 1;
            return calc < perc;
        }

        public static int CalculateSyncRPM(int measuredMotorHighRPM, int frequency)
        {
            var syncRPM = measuredMotorHighRPM / (double)frequency;

            switch (syncRPM)
            {
                case double n when n <= 10:
                    return frequency * 10;
                case double n when n <= 15:
                    return frequency * 15;
                case double n when n <= 20:
                    return frequency * 20;
                case double n when n <= 30:
                    return frequency * 30;
                case double n when n <= 60:
                    return frequency * 60;
            }
            return 0;
        }
    }
}
