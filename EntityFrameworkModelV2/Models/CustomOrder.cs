namespace EntityFrameworkModelV2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CustomOrder
    {
        public CustomOrder()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int CustomOrderNumber { get; set; }
        public string Debtor { get; set; }
        public string Reference { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}