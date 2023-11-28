using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BCustomOrderMotor
    {
        private static readonly List<string> _orderDisplayPropertyNames = new()
        {
            "Name", "Type", "Version", "IEC", "IP", "PTC", "HT", "BuildingType",
            "ISO", "HighPower", "LowPower", "HighRPM", "LowRPM", "HighAmperage",
            "LowAmperage", "HighStartupAmperage", "LowStartupAmperage", "Frequency",
            "PowerFactor", "VoltageType", "HighBearings", "LowBearings"
        };

        private static readonly List<string> _controleDisplayPropertyNames = new()
        {
            "Name", "Type", "Version", "HighPower", "LowPower", "HighRPM", "LowRPM",
            "HighAmperage", "LowAmperage", "HighStartupAmperage", "LowStartupAmperage",
            "Frequency", "HighBearings", "LowBearings"
        };

        private static readonly List<string> _selectDisplayPropertyNames = new()
        {
            "ID", "Name"
        };

        public static List<string> OrderDisplayPropertyNames => _orderDisplayPropertyNames;

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static List<string> SelectDisplayPropertyNames => _selectDisplayPropertyNames;

        public static CustomOrderMotor Create(CustomOrderMotor customOrderMotor)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            dbContext.CustomOrderMotors.Add(customOrderMotor);
            dbContext.SaveChanges();
            return customOrderMotor;
        }

        public static void Update(CustomOrderMotor customOrderMotor)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            var toUpdate = dbContext.CustomOrderMotors.Find(customOrderMotor.ID);
            if (toUpdate != null)
            {
                dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderMotor);
                dbContext.SaveChanges();
            }
        }

        public static bool Validate(CustomOrderMotor customOrderMotor)
        {
            if (customOrderMotor == null)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return false;
            }

            if (customOrderMotor.LowRPM > customOrderMotor.HighRPM)
            {
                MessageBox.Show("Creation failed. Motor low RPM can't be higher than high RPM");
                return false;
            }
            return true;
        }

        public static CustomOrderMotor CreateFromTemplate(TemplateMotor templateMotor)
        {
            return new CustomOrderMotor()
            {
                Name = templateMotor.Name,
                HighAmperage = templateMotor.HighAmperage,
                LowAmperage = templateMotor.LowAmperage,
                BuildingType = templateMotor.BuildingType,
                Frequency = templateMotor.Frequency,
                IEC = templateMotor.IEC,
                IP = templateMotor.IP,
                ISO = templateMotor.ISO,
                HighPower = templateMotor.HighPower,
                LowPower = templateMotor.LowPower,
                PowerFactor = templateMotor.PowerFactor,
                HighRPM = templateMotor.HighRPM,
                LowRPM = templateMotor.LowRPM,
                HighStartupAmperage = templateMotor.HighStartupAmperage,
                LowStartupAmperage = templateMotor.LowStartupAmperage,
                Type = templateMotor.Type,
                Version = templateMotor.Version,
                VoltageType = templateMotor.VoltageType,
                HighBearings = templateMotor.HighBearings,
                LowBearings = templateMotor.LowBearings
            };
        }

        public static void UpdateFromTemplate(CustomOrderMotor customOrderMotor, TemplateMotor templateMotor)
        {
            customOrderMotor.Name = templateMotor.Name;
            customOrderMotor.HighAmperage = templateMotor.HighAmperage;
            customOrderMotor.LowAmperage = templateMotor.LowAmperage;
            customOrderMotor.BuildingType = templateMotor.BuildingType;
            customOrderMotor.Frequency = templateMotor.Frequency;
            customOrderMotor.IEC = templateMotor.IEC;
            customOrderMotor.IP = templateMotor.IP;
            customOrderMotor.ISO = templateMotor.ISO;
            customOrderMotor.HighPower = templateMotor.HighPower;
            customOrderMotor.LowPower = templateMotor.LowPower;
            customOrderMotor.PowerFactor = templateMotor.PowerFactor;
            customOrderMotor.HighRPM = templateMotor.HighRPM;
            customOrderMotor.LowRPM = templateMotor.LowRPM;
            customOrderMotor.HighStartupAmperage = templateMotor.HighStartupAmperage;
            customOrderMotor.LowStartupAmperage = templateMotor.LowStartupAmperage;
            customOrderMotor.Type = templateMotor.Type;
            customOrderMotor.Version = templateMotor.Version;
            customOrderMotor.VoltageType = templateMotor.VoltageType;
            customOrderMotor.HighBearings = templateMotor.HighBearings;
            customOrderMotor.LowBearings = templateMotor.LowBearings;
        }

        public static CustomOrderMotor CreateObject(CustomOrderMotor customOrderMotor, List<DataGridViewRow> rows)
        {
            try
            {
                customOrderMotor.Name = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.Name));
                customOrderMotor.Type = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.Type));
                customOrderMotor.Version = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.Version));
                customOrderMotor.IEC = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.IEC));
                customOrderMotor.IP = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.IP));
                customOrderMotor.BuildingType = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.BuildingType));
                customOrderMotor.ISO = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.ISO));
                customOrderMotor.HighPower = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.HighPower));
                customOrderMotor.LowPower = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.LowPower));
                customOrderMotor.HighRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.HighRPM));
                customOrderMotor.LowRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.LowRPM));
                customOrderMotor.HighAmperage = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.HighAmperage));
                customOrderMotor.LowAmperage = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.LowAmperage));
                customOrderMotor.HighStartupAmperage = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.HighStartupAmperage));
                customOrderMotor.LowStartupAmperage = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.LowStartupAmperage));
                customOrderMotor.Frequency = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.Frequency));
                customOrderMotor.PowerFactor = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderMotor.PowerFactor));
                customOrderMotor.VoltageType = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderMotor.VoltageType));
                customOrderMotor.HighBearings = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.HighBearings));
                customOrderMotor.LowBearings = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderMotor.LowBearings));
                return customOrderMotor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}