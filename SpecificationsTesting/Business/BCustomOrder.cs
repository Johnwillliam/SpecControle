using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
  public class BCustomOrder
  {
    public static List<string> DisplayPropertyNames = new List<string>
        {
            "CustomOrderNumber", "Debtor", "Reference", "Remarks"
        };

    public static CustomOrder Create(int customOrderNumber, int type, string debtor = "", string reference = "", string remarks = "")
    {
      var dbContext = new SpecificationsDatabaseModel();
      var newCO = new CustomOrder()
      {
        CustomOrderNumber = customOrderNumber,
        Type = type,
        Debtor = debtor,
        Reference = reference,
        Remarks = remarks
      };
      dbContext.CustomOrders.Add(newCO);
      dbContext.SaveChanges();
      return newCO;
    }

    public static CustomOrder Create(CustomOrder customOrder)
    {
      var dbContext = new SpecificationsDatabaseModel();
      dbContext.CustomOrders.Add(customOrder);
      dbContext.SaveChanges();
      return customOrder;
    }

    public static CustomOrder ByCustomOrderNumber(int customOrderNumber)
    {
      var dbContext = new SpecificationsDatabaseModel();
      return dbContext.CustomOrders.Any(x => x.CustomOrderNumber == customOrderNumber) ? dbContext.CustomOrders.Single(x => x.CustomOrderNumber == customOrderNumber) : null;
    }

    public static CustomOrder Copy(int id, int customOrderNumber)
    {
      var dbContext = new SpecificationsDatabaseModel();
      var entity = dbContext.CustomOrders
                    .AsNoTracking()
                    .Include(x => x.CustomOrderVentilators)
                    .FirstOrDefault(x => x.ID == id);

      entity.CustomOrderNumber = customOrderNumber;
      dbContext.CustomOrders.Add(entity);
      dbContext.SaveChanges();
      return entity;
    }

  }
}
