namespace EntityFrameworkModelV2.Models
{
    using System.Collections.Generic;

    public partial class CatType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatType()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}