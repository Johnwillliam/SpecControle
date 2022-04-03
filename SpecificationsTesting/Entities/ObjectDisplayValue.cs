using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpecificationsTesting.Entities
{
    public class ObjectDisplayValue
    {
        public string Description { get; set; }
        public object Value { get; set; }
        public string DisplayValue { get; set; }

        public static List<ObjectDisplayValue> GetDisplayValues(Type objectType, object displayObject, List<string> displayPropertyNames)
        {
            IEnumerable<PropertyInfo> propertiesToDisplay = objectType.GetProperties().Where(propertyInfo => displayPropertyNames.Contains(propertyInfo.Name) && propertyInfo.CanRead);
            var valuesToDisplay = new List<ObjectDisplayValue>();
            foreach (var property in propertiesToDisplay)
            {
                var displayValue = new ObjectDisplayValue()
                {
                    Description = property.Name, // Regex.Replace(property.Name, "([A-Z])", " $1").Trim(),
                    Value = displayObject == null ? "" : property.GetValue(displayObject),
                };
                if (displayValue.Value?.GetType() == typeof(DateTime))
                    displayValue.DisplayValue = ((DateTime?)displayValue.Value)?.ToString("dd-MM-yyyy");
                else
                    displayValue.DisplayValue = displayValue.Value?.ToString();

                valuesToDisplay.Add(displayValue);

            }
            return valuesToDisplay;
        }
    }
}
