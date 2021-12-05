using System;
using System.Collections;
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
    public string DisplayValue { get; set; }

    public static List<ObjectDisplayValue> GetDisplayValues(Type objectType, object displayObject, List<string> displayPropertyNames)
    {
      IEnumerable<PropertyInfo> propertiesToDisplay = objectType.GetProperties().Where(propertyInfo => displayPropertyNames.Contains(propertyInfo.Name) && propertyInfo.CanRead);
      var valuesToDisplay = new List<ObjectDisplayValue>();
      foreach (var property in propertiesToDisplay)
      {
        var displayValue = new ObjectDisplayValue()
        {
          Description = property.Name,
          Value = displayObject == null ? "" : property.GetValue(displayObject),
        };
        displayValue.DisplayValue = displayValue.Value?.ToString();
        valuesToDisplay.Add(displayValue);

      }
      return valuesToDisplay;
    }
  }
}
