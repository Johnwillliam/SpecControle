namespace Infrastructure.Models
{
    using System.Collections.Generic;

    public partial class CatType
    {
        public CatType()
        {
            CustomOrderVentilators = new HashSet<CustomOrderVentilator>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CustomOrderVentilator> CustomOrderVentilators { get; set; }
    }
}