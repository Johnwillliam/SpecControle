using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class SoundLevelTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        private string _uOM;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        private ICollection<TemplateVentilator> _templateVentilators;
        
        public SoundLevelTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _uOM = "UOM1";
            _customOrderVentilators = null;
            _templateVentilators = null;
        }
        
        public SoundLevelTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public SoundLevelTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public SoundLevelTypeBuilder WithUOM(string uOM)
        {
            _uOM = uOM;
            return this;
        }
        
        public SoundLevelTypeBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public SoundLevelTypeBuilder WithTemplateVentilators(ICollection<TemplateVentilator> templateVentilators)
        {
            _templateVentilators = templateVentilators;
            return this;
        }
        
        public SoundLevelType Build()
        {
            return new SoundLevelType()
            {
                ID = _iD,
                Description = _description,
                UOM = _uOM,
                CustomOrderVentilators = _customOrderVentilators,
                TemplateVentilators = _templateVentilators,
            };
        }
        
    }
}
