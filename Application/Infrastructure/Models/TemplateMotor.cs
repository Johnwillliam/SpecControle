using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class TemplateMotor
    {
        public TemplateMotor()
        {
        }

        public TemplateMotor(int iD, string name, string type, string version, int? iEC, int? iP, bool? ptc, bool? ht, string buildingType, string iSO, decimal? highPower, decimal? lowPower, int? highRPM, int? lowRPM, decimal? highAmperage, decimal? lowAmperage, decimal? highStartupAmperage, decimal? lowStartupAmperage, string voltageType, int? frequency, decimal? powerFactor, string bearings)
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
            Bearings = bearings;
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

        [Precision(18, 2)]
        public decimal? HighPower { get; set; }

        [Precision(18, 2)]
        public decimal? LowPower { get; set; }

        public int? HighRPM { get; set; }
        public int? LowRPM { get; set; }

        [Precision(18, 2)]
        public decimal? HighAmperage { get; set; }

        [Precision(18, 2)]
        public decimal? LowAmperage { get; set; }

        [Precision(18, 2)]
        public decimal? HighStartupAmperage { get; set; }

        [Precision(18, 2)]
        public decimal? LowStartupAmperage { get; set; }

        public string VoltageType { get; set; }
        public int? Frequency { get; set; }
        public int? Poles { get; set; }

        [Precision(18, 2)]
        public decimal? PowerFactor { get; set; }

        public string Bearings { get; set; }
    }
}