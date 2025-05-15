namespace Infrastructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            CustomOrderVentilatorTests = new HashSet<CustomOrderVentilatorTest>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CustomOrderVentilatorTest> CustomOrderVentilatorTests { get; set; }
    }
}