namespace Infrastructure.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Lookup table with the applications a fan is suitable for (Marine, Transport, ...).
    /// Regulations require the chosen application to be printed on the type plate sticker.
    /// </summary>
    public class FanApplication
    {
        public FanApplication()
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
