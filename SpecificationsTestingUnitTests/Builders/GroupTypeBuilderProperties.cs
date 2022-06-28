using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class GroupTypeBuilder
    {
        private int _iD;
        
        private string _description;
        
        private ICollection<CustomOrderVentilator> _customOrderVentilators;
        
        public GroupTypeBuilder()
        {
            _iD = 1;
            _description = "Description1";
            _customOrderVentilators = null;
        }
        
        public GroupTypeBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public GroupTypeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        
        public GroupTypeBuilder WithCustomOrderVentilators(ICollection<CustomOrderVentilator> customOrderVentilators)
        {
            _customOrderVentilators = customOrderVentilators;
            return this;
        }
        
        public GroupType Build()
        {
            return new GroupType()
            {
                ID = _iD,
                Description = _description,
                CustomOrderVentilators = _customOrderVentilators,
            };
        }
        
    }
}
