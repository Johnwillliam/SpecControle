using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;
using System.Data.Entity.Migrations;
using System.Threading;

namespace SpecificationsTesting.Business
{
  public class BCustomOrderVentilator
  {
    public static List<string> DisplayPropertyNames = new List<string>
        {
            "Name", "AirVolume", "PressureTotal", "PressureStatic", "PressureDynamic",
            "RPM", "Efficiency", "ShaftPower", "SoundLevel", "BladeAngle"
        };

    public static CustomOrderVentilator Create(CustomOrderVentilator customOrderVentilator)
    {
      var dbContext = new SpecificationsDatabaseModel();
      dbContext.CustomOrderVentilators.Add(customOrderVentilator);
      dbContext.SaveChanges();
      return customOrderVentilator;
    }

    public static void Update(CustomOrderVentilator customOrderVentilator)
    {
      var dbContext = new SpecificationsDatabaseModel();
      var toUpdate = dbContext.CustomOrderVentilators.Find(customOrderVentilator.ID);
      if (toUpdate != null)
      {
        customOrderVentilator.CustomOrderID = toUpdate.CustomOrderID;
        dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilator);
        dbContext.SaveChanges();
        Thread.Sleep(500);
      }
    }

  }
}
