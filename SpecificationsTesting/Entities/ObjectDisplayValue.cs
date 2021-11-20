using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationsTesting.Entities
{
    public class ObjectDisplayValue
    {
        public string Description { get; set; }
        public object Value { get; set; }
        public string DisplayedValue { get { return Value?.ToString(); } }

        public static IEnumerable<ObjectDisplayValue> GetDisplayValues(Type objectType, object displayObject, List<string> displayPropertyNames)
        {
            IEnumerable<PropertyInfo> propertiesToDisplay = objectType.GetProperties().Where(propertyInfo => displayPropertyNames.Contains(propertyInfo.Name) && propertyInfo.CanRead);
            var valuesToDisplay = new List<ObjectDisplayValue>();
            foreach (var property in propertiesToDisplay)
            {
                valuesToDisplay.Add(new ObjectDisplayValue()
                {
                    Description = property.Name,
                    Value = property.GetValue(displayObject),
                });
            }
            return valuesToDisplay;
        }
    }
}
