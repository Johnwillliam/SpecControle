using System.Collections.Generic;

namespace EntityFrameworkModel
{
    public class UserBuilder
    {
        private int _iD;
        
        private string _name;
        
        private ICollection<CustomOrderVentilatorTest> _customOrderVentilatorTests;
        
        public UserBuilder()
        {
            _iD = 1;
            _name = "Name1";
            _customOrderVentilatorTests = null;
        }
        
        public UserBuilder WithID(int iD)
        {
            _iD = iD;
            return this;
        }
        
        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public UserBuilder WithCustomOrderVentilatorTests(ICollection<CustomOrderVentilatorTest> customOrderVentilatorTests)
        {
            _customOrderVentilatorTests = customOrderVentilatorTests;
            return this;
        }
        
        public User Build()
        {
            return new User()
            {
                ID = _iD,
                Name = _name,
                CustomOrderVentilatorTests = _customOrderVentilatorTests,
            };
        }
        
    }
}
