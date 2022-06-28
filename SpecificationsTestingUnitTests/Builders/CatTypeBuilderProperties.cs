using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class CatTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        public CatTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _customOrderVentilators = null;
        }
        
        public CatTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public CatTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public CatTypeBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public CatType Build()
        {
            return new CatType()
            {
                ID = _iD,
                Description = _description,
                CustomOrderVentilators = _customOrderVentilators,
            };
        }
        
    }
}
