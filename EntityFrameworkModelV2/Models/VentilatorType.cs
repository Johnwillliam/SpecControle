namespace EntityFrameworkModelV2.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class VentilatorType
    {
        public VentilatorType()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
            TemplateVentilators = new HashSet<TemplateVentilator>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }

        public virtual ICollection<TemplateVentilator> TemplateVentilators { get; set; }
    }
}