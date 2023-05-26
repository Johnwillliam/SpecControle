namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;

    public class CustomOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomOrder()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        public int ID { get; set; }
        public int CustomOrderNumber { get; set; }
        public string Debtor { get; set; }
        public string Reference { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}
