namespace Infrastructure.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure.Models;

    public class TemplateVentilator
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }
        public int? VentilatorTypeID { get; set; }
        public int? AirVolume { get; set; }
        public int? PressureTotal { get; set; }
        public int? PressureStatic { get; set; }
        public int? PressureDynamic { get; set; }
        public int? RPM { get; set; }
        public int? Efficiency { get; set; }
        public int? ShaftPower { get; set; }
        public int? SoundLevel { get; set; }
        public int? SoundLevelTypeID { get; set; }
        public int? BladeAngle { get; set; }

        public virtual SoundLevelType SoundLevelType { get; set; }
        public virtual VentilatorType VentilatorType { get; set; }
    }
}
