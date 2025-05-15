namespace Infrastructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TemperatureClass
    {
        public TemperatureClass()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}