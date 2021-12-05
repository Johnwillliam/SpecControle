using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
  public class BCustomOrderMotor
  {
    public static List<string> EditDisplayPropertyNames = new List<string>
        {
            "Name", "Type", "Version", "IEC", "IP", "BuildingType",
            "ISO", "Power", "RPM", "Amperage", "StartupAmperage"
        };

    public static List<string> SelectDisplayPropertyNames = new List<string>
        {
            "ID", "Name"
        };

    public static CustomOrderMotor Create(CustomOrderMotor customOrderMotor)
    {
      var dbContext = new SpecificationsDatabaseModel();
      dbContext.CustomOrderMotors.Add(customOrderMotor);
      dbContext.SaveChanges();
      return customOrderMotor;
    }
  }
}
