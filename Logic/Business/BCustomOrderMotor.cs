using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BCustomOrderMotor
    {
        private static readonly List<string> _orderDisplayPropertyNames = new List<string>
        {
            "Name", "Type", "Version", "IEC", "IP", "BuildingType",
            "ISO", "HighPower", "LowPower", "HighRPM", "LowRPM", "HighAmperage", 
            "LowAmperage", "HighStartupAmperage", "LowStartupAmperage", "Frequency", 
            "PowerFactor", "VoltageType", "HighBearings", "LowBearings"
        };

        private static readonly List<string> _controleDisplayPropertyNames = new List<string>
        {
            "Name", "Type", "Version", "HighPower", "LowPower", "HighRPM", "LowRPM", 
            "HighAmperage", "LowAmperage", "HighStartupAmperage", "LowStartupAmperage", 
            "Frequency", "HighBearings", "LowBearings"
        };

        private static readonly List<string> _selectDisplayPropertyNames = new List<string>
        {
            "ID", "Name"
        };

        public static List<string> OrderDisplayPropertyNames => _orderDisplayPropertyNames;

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static List<string> SelectDisplayPropertyNames => _selectDisplayPropertyNames;

        public static CustomOrderMotor Create(CustomOrderMotor customOrderMotor)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrderMotors.Add(customOrderMotor);
                dbContext.SaveChanges();
                return customOrderMotor;
            }
        }

        public static void Update(CustomOrderMotor customOrderMotor)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var toUpdate = dbContext.CustomOrderMotors.Find(customOrderMotor.ID);
                if (toUpdate != null)
                {
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderMotor);
                    dbContext.SaveChanges();
                }
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
                VoltageType = templateMotor.VoltageType
            };
        }

        public static CustomOrderMotor CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var cellColumnName = "Description";
                var cellValueColumnName = "Value";
                var newCustomOrderMotor = new CustomOrderMotor();
                var name = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("Name")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.Name = name.ToString();

                var type = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("Type")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.Type = type == null ? "" : type.ToString();

                var version = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("Version")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.Version = version == null ? "" : version.ToString();

                var iec = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("IEC")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.IEC = DataHelper.ToNullableInt(iec?.ToString());

                var ip = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("IP")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.IP = DataHelper.ToNullableInt(ip?.ToString());

                var buildingType = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("BuildingType")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.BuildingType = buildingType == null ? "" : buildingType.ToString();

                var iso = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("ISO")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.ISO = iso == null ? "" : iso.ToString();

                var highPower = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("HighPower")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.HighPower = DataHelper.ToNullableDecimal(highPower?.ToString());

                var lowPower = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("LowPower")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.LowPower = DataHelper.ToNullableDecimal(lowPower?.ToString());

                var highRPM = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("HighRPM")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.HighRPM = DataHelper.ToNullableInt(highRPM?.ToString());

                var lowRPM = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("LowRPM")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.LowRPM = DataHelper.ToNullableInt(lowRPM?.ToString());

                var highAmperage = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("HighAmperage")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.HighAmperage = DataHelper.ToNullableDecimal(highAmperage?.ToString());

                var lowAmperage = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("LowAmperage")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.LowAmperage = DataHelper.ToNullableDecimal(lowAmperage?.ToString());

                var highStartupAmperage = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("HighStartupAmperage")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.HighStartupAmperage = DataHelper.ToNullableDecimal(highStartupAmperage?.ToString());

                var lowStartupAmperage = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("LowStartupAmperage")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.LowStartupAmperage = DataHelper.ToNullableDecimal(lowStartupAmperage?.ToString());

                var frequency = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("Frequency")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.Frequency = DataHelper.ToNullableInt(frequency?.ToString());

                var powerFactor = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("PowerFactor")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.PowerFactor = DataHelper.ToNullableDecimal(powerFactor?.ToString());

                var voltageType = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("VoltageType")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.VoltageType = voltageType?.ToString();

                var highBearings = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("HighBearings")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.HighBearings = DataHelper.ToNullableInt(highBearings?.ToString());

                var lowBearings = rows.First(x => x.Cells[cellColumnName].Value.ToString().Equals("LowBearings")).Cells[cellValueColumnName].Value;
                newCustomOrderMotor.LowBearings = DataHelper.ToNullableInt(lowBearings?.ToString());

                return newCustomOrderMotor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
