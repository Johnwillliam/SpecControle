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
            "CustomOrderNumber", "Amount", "Debtor", "Reference", "Remarks"
        };

    public static CustomOrder Create(int customOrderNumber, int type, int amount, string debtor = "", string reference = "", string remarks = "")
    {
      var dbContext = new SpecificationsDatabaseModel();
      var newCO = new CustomOrder()
      {
        CustomOrderNumber = customOrderNumber,
        Type = type,
        Amount = amount,
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

  }
}
