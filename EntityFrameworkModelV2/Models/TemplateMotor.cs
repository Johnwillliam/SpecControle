using EntityFrameworkModelV2.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;

namespace EntityFrameworkModelV2.Models
{
    public class TemplateMotor
    {
        public TemplateMotor()
        {
        }

        public TemplateMotor(DataGridViewRow dataRow)
        {
            ID = (int)dataRow.Cells[nameof(TemplateMotor.ID)].Value;
            Name = dataRow.Cells[nameof(TemplateMotor.Name)].Value.EmptyIfNull();
            Type = dataRow.Cells[nameof(TemplateMotor.Type)].Value.EmptyIfNull();
            Version = dataRow.Cells[nameof(TemplateMotor.Version)].Value.EmptyIfNull();
            IEC = (int?)dataRow.Cells[nameof(TemplateMotor.IEC)].Value;
            IP = (int?)dataRow.Cells[nameof(TemplateMotor.IP)].Value;
            PTC = (bool?)dataRow.Cells[nameof(TemplateMotor.PTC)].Value;
            HT = (bool?)dataRow.Cells[nameof(TemplateMotor.HT)].Value;
            BuildingType = dataRow.Cells[nameof(TemplateMotor.BuildingType)].Value.EmptyIfNull();
            ISO = dataRow.Cells[nameof(TemplateMotor.ISO)].Value.EmptyIfNull();
            HighPower = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighPower)].Value;
            LowPower = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowPower)].Value;
            HighRPM = (int?)dataRow.Cells[nameof(TemplateMotor.HighRPM)].Value;
            LowRPM = (int?)dataRow.Cells[nameof(TemplateMotor.LowRPM)].Value;
            HighAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighAmperage)].Value;
            LowAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowAmperage)].Value;
            HighStartupAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.HighStartupAmperage)].Value;
            LowStartupAmperage = (decimal?)dataRow.Cells[nameof(TemplateMotor.LowStartupAmperage)].Value;
            VoltageType = dataRow.Cells[nameof(TemplateMotor.VoltageType)].Value.EmptyIfNull();
            Frequency = (int?)dataRow.Cells[nameof(TemplateMotor.Frequency)].Value;
            PowerFactor = (decimal?)dataRow.Cells[nameof(TemplateMotor.PowerFactor)].Value;
            HighBearings = (int?)dataRow.Cells[nameof(TemplateMotor.HighBearings)].Value;
            LowBearings = (int?)dataRow.Cells[nameof(TemplateMotor.LowBearings)].Value;
        }

        public TemplateMotor(int iD, string name, string type, string version, int? iEC, int? iP, bool? ptc, bool? ht, string buildingType, string iSO, decimal? highPower, decimal? lowPower, int? highRPM, int? lowRPM, decimal? highAmperage, decimal? lowAmperage, decimal? highStartupAmperage, decimal? lowStartupAmperage, string voltageType, int? frequency, decimal? powerFactor, int? highBearings, int? lowBearings)
        {
            ID = iD;
            Name = name;
            Type = type;
            Version = version;
            IEC = iEC;
            IP = iP;
            PTC = ptc;
            HT = ht;
            BuildingType = buildingType;
            ISO = iSO;
            HighPower = highPower;
            LowPower = lowPower;
            HighRPM = highRPM;
            LowRPM = lowRPM;
            HighAmperage = highAmperage;
            LowAmperage = lowAmperage;
            HighStartupAmperage = highStartupAmperage;
            LowStartupAmperage = lowStartupAmperage;
            VoltageType = voltageType;
            Frequency = frequency;
            PowerFactor = powerFactor;
            HighBearings = highBearings;
            LowBearings = lowBearings;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public int? IEC { get; set; }
        public int? IP { get; set; }
        public bool? PTC { get; set; }
        public bool? HT { get; set; }
        public string BuildingType { get; set; }
        public string ISO { get; set; }
        public decimal? HighPower { get; set; }
        public decimal? LowPower { get; set; }
        public int? HighRPM { get; set; }
        public int? LowRPM { get; set; }
        public decimal? HighAmperage { get; set; }
        public decimal? LowAmperage { get; set; }
        public decimal? HighStartupAmperage { get; set; }
        public decimal? LowStartupAmperage { get; set; }
        public string VoltageType { get; set; }
        public int? Frequency { get; set; }
        public decimal? PowerFactor { get; set; }
        public int? HighBearings { get; set; }
        public int? LowBearings { get; set; }
    }
}