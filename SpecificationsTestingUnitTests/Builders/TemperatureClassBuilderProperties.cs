using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class TemperatureClassBuilder
    {
        private int _iD;
        
        private string _description;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        public TemperatureClassBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _customOrderVentilators = null;
        }
        
        public TemperatureClassBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public TemperatureClassBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public TemperatureClassBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public TemperatureClass Build()
        {
            return new TemperatureClass()
            {
                ID = _iD,
                Description = _description,
                CustomOrderVentilators = _customOrderVentilators,
            };
        }
        
    }
}
