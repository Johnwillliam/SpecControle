using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
  public class BTemplateMotor
  {
    public static List<TemplateMotor> GetAll()
    {
      var dbContext = new SpecificationsDatabaseModel();
      return dbContext.TemplateMotors.ToList();
    }

    public static TemplateMotor GetById(int id)
    {
      var dbContext = new SpecificationsDatabaseModel();
      return dbContext.TemplateMotors.Find(id);
    }

  }
}
