using EntityFrameworkModelV2.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkModelV2.Models
{
    public class CustomOrderVentilator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomOrderVentilator()
        {
            CustomOrderVentilatorTests = new HashSet<CustomOrderVentilatorTest>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CustomOrderID { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public int CustomOrderMotorID { get; set; }
        public int? VentilatorTypeID { get; set; }
        public int? HighAirVolume { get; set; }
        public int? LowAirVolume { get; set; }
        public int? HighPressureTotal { get; set; }
        public int? LowPressureTotal { get; set; }
        public int? HighPressureStatic { get; set; }
        public int? LowPressureStatic { get; set; }
        public int? HighPressureDynamic { get; set; }
        public int? LowPressureDynamic { get; set; }
        public int? HighRPM { get; set; }
        public int? LowRPM { get; set; }
        public int? Efficiency { get; set; }
        public decimal? HighShaftPower { get; set; }
        public decimal? LowShaftPower { get; set; }
        public int? SoundLevel { get; set; }
        public int? SoundLevelTypeID { get; set; }
        public int? BladeAngle { get; set; }
        public string? Atex { get; set; }
        public int? GroupTypeID { get; set; }
        public int? TemperatureClassID { get; set; }
        public int? CatTypeID { get; set; }
        public int? CatOutID { get; set; }
        public virtual CatType? CatType { get; set; }
        public virtual CustomOrderMotor CustomOrderMotor { get; set; }
        public virtual CustomOrder CustomOrder { get; set; }
        public virtual SoundLevelType? SoundLevelType { get; set; }
        public virtual GroupType? GroupType { get; set; }
        public virtual TemperatureClass? TemperatureClass { get; set; }
        public virtual VentilatorType? VentilatorType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomOrderVentilatorTest> CustomOrderVentilatorTests { get; set; }

        public bool IsAtex()
        {
            if(GroupTypeID.HasValue && GroupType == null)
            {
                GroupType = new SpecificationsDatabaseModel().GroupTypes.Find(GroupTypeID);
            }

            return !string.IsNullOrEmpty(Atex) && GroupType != null && !GroupType.Description.ToLower().Contains("n.v.t");
        }

        public bool IsDirectBelt()
        {
            if (VentilatorTypeID.HasValue && VentilatorType == null)
            {
                VentilatorType = new SpecificationsDatabaseModel().VentilatorTypes.Find(VentilatorTypeID);
            }

            return VentilatorType != null && !VentilatorType.Description.ToUpper().Contains("V-BELT") && !VentilatorType.Description.ToUpper().Contains("VBELT");
        }
    }
}
