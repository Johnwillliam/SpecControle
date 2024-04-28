using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkModelV2.Models
{
    public class CustomOrderMotor
    {
        public CustomOrderMotor()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public IEnumerable<int> Bearings { get; set; }
        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}