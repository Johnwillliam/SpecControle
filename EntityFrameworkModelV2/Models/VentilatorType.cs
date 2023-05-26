namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;

    public class VentilatorType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VentilatorType()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
            TemplateVentilators = new HashSet<TemplateVentilator>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TemplateVentilator> TemplateVentilators { get; set; }
    }
}
