namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data;
	using System.Windows.Forms;
	public class TemplateMotor
	{
		public TemplateMotor()
		{ 
        }

        public TemplateMotor(DataGridViewRow dataRow)
        {
            ID = (int)dataRow.Cells["ID"].Value;
            Name = dataRow.Cells["Name"].Value.EmptyIfNull();
            Type = dataRow.Cells["Type"].Value.EmptyIfNull();
            Version = dataRow.Cells["Version"].Value.EmptyIfNull();
            IEC = (int?)dataRow.Cells["IEC"].Value;
            IP = (int?)dataRow.Cells["IP"].Value;
            BuildingType = dataRow.Cells["BuildingType"].Value.EmptyIfNull();
            ISO = dataRow.Cells["ISO"].Value.EmptyIfNull();
            HighPower = (decimal?)dataRow.Cells["HighPower"].Value;
            LowPower = (decimal?)dataRow.Cells["LowPower"].Value;
            HighRPM = (int?)dataRow.Cells["HighRPM"].Value;
            LowRPM = (int?)dataRow.Cells["LowRPM"].Value;
            HighAmperage = (decimal?)dataRow.Cells["HighAmperage"].Value;
            LowAmperage = (decimal?)dataRow.Cells["LowAmperage"].Value;
            StartupAmperage = (decimal?)dataRow.Cells["StartupAmperage"].Value;
            VoltageType = dataRow.Cells["VoltageType"].Value.EmptyIfNull();
            Frequency = (int?)dataRow.Cells["Frequency"].Value;
            PowerFactor = (int?)dataRow.Cells["PowerFactor"].Value;
        }

        public TemplateMotor(int iD, string name, string type, string version, int? iEC, int? iP, string buildingType, string iSO, decimal? highPower, decimal? lowPower, int? highRPM, int? lowRPM, decimal? highAmperage, decimal? lowAmperage, decimal? startupAmperage, string voltageType, int? frequency, int? powerFactor)
        {
            ID = iD;
            Name = name;
            Type = type;
            Version = version;
            IEC = iEC;
            IP = iP;
            BuildingType = buildingType;
            ISO = iSO;
            HighPower = highPower;
            LowPower = lowPower;
            HighRPM = highRPM;
            LowRPM = lowRPM;
            HighAmperage = highAmperage;
            LowAmperage = lowAmperage;
            StartupAmperage = startupAmperage;
            VoltageType = voltageType;
            Frequency = frequency;
            PowerFactor = powerFactor;
        }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key, Column(Order = 0)]
		public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public int? IEC { get; set; }
        public int? IP { get; set; }
        public string BuildingType { get; set; }
        public string ISO { get; set; }
        public decimal? HighPower { get; set; }
        public decimal? LowPower { get; set; }
        public int? HighRPM { get; set; }
        public int? LowRPM { get; set; }
        public decimal? HighAmperage { get; set; }
        public decimal? LowAmperage { get; set; }
        public decimal? StartupAmperage { get; set; }
        public string VoltageType { get; set; }
        public int? Frequency { get; set; }
        public int? PowerFactor { get; set; }
    }
}
