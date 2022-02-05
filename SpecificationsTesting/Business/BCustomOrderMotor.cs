using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderMotor
    {
        public static List<string> OrderDisplayPropertyNames = new List<string>
        {
            "Name", "Type", "Version", "IEC", "IP", "BuildingType",
            "ISO", "HighPower", "LowPower", "HighRPM", "LowRPM", "HighAmperage", "LowAmperage", "StartupAmperage", "Frequency", "PowerFactor"
        };

        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "Name", "Type", "Version", "HighPower", "LowPower", "HighRPM", "LowRPM", "HighAmperage", "LowAmperage", "StartupAmperage", "Frequency"
        };

        public static List<string> SelectDisplayPropertyNames = new List<string>
        {
            "ID", "Name"
        };

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
                    Thread.Sleep(300);
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
            return true;
        }

        public static CustomOrderMotor CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderMotor = new CustomOrderMotor();

                var name = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Name")).Cells["Value"].Value;
                newCustomOrderMotor.Name = name.ToString();

                var type = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Type")).Cells["Value"].Value;
                newCustomOrderMotor.Type = type == null ? "" : type.ToString();

                var version = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Version")).Cells["Value"].Value;
                newCustomOrderMotor.Version = version == null ? "" : version.ToString();

                var iec = rows.First(x => x.Cells["Description"].Value.ToString().Equals("IEC")).Cells["Value"].Value;
                newCustomOrderMotor.IEC = DataHelper.ToNullableInt(iec?.ToString());

                var ip = rows.First(x => x.Cells["Description"].Value.ToString().Equals("IP")).Cells["Value"].Value;
                newCustomOrderMotor.IP = DataHelper.ToNullableInt(ip?.ToString());

                var buildingType = rows.First(x => x.Cells["Description"].Value.ToString().Equals("BuildingType")).Cells["Value"].Value;
                newCustomOrderMotor.BuildingType = buildingType == null ? "" : buildingType.ToString();

                var iso = rows.First(x => x.Cells["Description"].Value.ToString().Equals("ISO")).Cells["Value"].Value;
                newCustomOrderMotor.ISO = iso == null ? "" : iso.ToString();

                var highPower = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighPower")).Cells["Value"].Value;
                newCustomOrderMotor.HighPower = DataHelper.ToNullableDecimal(highPower?.ToString());

                var lowPower = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowPower")).Cells["Value"].Value;
                newCustomOrderMotor.LowPower = DataHelper.ToNullableDecimal(lowPower?.ToString());

                var highRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighRPM")).Cells["Value"].Value;
                newCustomOrderMotor.HighRPM = DataHelper.ToNullableInt(highRPM?.ToString());

                var lowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowRPM")).Cells["Value"].Value;
                newCustomOrderMotor.LowRPM = DataHelper.ToNullableInt(lowRPM?.ToString());

                var highAmperage = rows.First(x => x.Cells["Description"].Value.ToString().Equals("HighAmperage")).Cells["Value"].Value;
                newCustomOrderMotor.HighAmperage = DataHelper.ToNullableDecimal(highAmperage?.ToString());

                var lowAmperage = rows.First(x => x.Cells["Description"].Value.ToString().Equals("LowAmperage")).Cells["Value"].Value;
                newCustomOrderMotor.LowAmperage = DataHelper.ToNullableDecimal(lowAmperage?.ToString());

                var startupAmperage = rows.First(x => x.Cells["Description"].Value.ToString().Equals("StartupAmperage")).Cells["Value"].Value;
                newCustomOrderMotor.StartupAmperage = DataHelper.ToNullableInt(startupAmperage?.ToString());

                var frequency = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Frequency")).Cells["Value"].Value;
                newCustomOrderMotor.Frequency = DataHelper.ToNullableInt(frequency?.ToString());

                var powerFactor = rows.First(x => x.Cells["Description"].Value.ToString().Equals("PowerFactor")).Cells["Value"].Value;
                newCustomOrderMotor.PowerFactor = DataHelper.ToNullableInt(powerFactor?.ToString());

                return newCustomOrderMotor;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
