using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class VoltageTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        private ICollection<CustomOrderMotor> _customOrderMotors;
        
        private ICollection<TemplateMotor> _templateMotors;
        
        public VoltageTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _customOrderMotors = null;
            _templateMotors = null;
        }
        
        public VoltageTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public VoltageTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public VoltageTypeBuilder WithCustomOrderMotors(ICollection<CustomOrderMotor> customOrderMotors)
        {
            _customOrderMotors = customOrderMotors;
            return this;
        }
        
        public VoltageTypeBuilder WithTemplateMotors(ICollection<TemplateMotor> templateMotors)
        {
            _templateMotors = templateMotors;
            return this;
        }
        
        public VoltageType Build()
        {
            return new VoltageType()
            {
                ID = _iD,
                Description = _description,
                CustomOrderMotors = _customOrderMotors,
                TemplateMotors = _templateMotors,
            };
        }
        
    }
}
