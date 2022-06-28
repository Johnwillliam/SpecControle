using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class VentilatorTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        private ICollection<TemplateVentilator> _templateVentilators;
        
        public VentilatorTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _customOrderVentilators = null;
            _templateVentilators = null;
        }
        
        public VentilatorTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public VentilatorTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public VentilatorTypeBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public VentilatorTypeBuilder WithTemplateVentilators(ICollection<TemplateVentilator> templateVentilators)
        {
            _templateVentilators = templateVentilators;
            return this;
        }
        
        public VentilatorType Build()
        {
            return new VentilatorType()
            {
                ID = _iD,
                Description = _description,
                CustomOrderVentilators = _customOrderVentilators,
                TemplateVentilators = _templateVentilators,
            };
        }
        
    }
}
