namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            CustomOrderVentilatorTests = new HashSet<CustomOrderVentilatorTest>();
        }

        public int ID { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomOrderVentilatorTest> CustomOrderVentilatorTests { get; set; }
    }
}
