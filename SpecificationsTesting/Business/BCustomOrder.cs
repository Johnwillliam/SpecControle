using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrder
    {
        private static readonly SpecificationsDatabaseModel dbContext = new SpecificationsDatabaseModel();
        public static List<string> DisplayPropertyNames = new List<string>
        {
            "ID", "CustomOrderNumber", "Amount", "Debtor", "Reference", "Remarks"
        };

        public static CustomOrder Create(int customOrderNumber, int type, int amount, string debtor = "", string reference = "", string remarks = "")
        {
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

        public static CustomOrder ByCustomOrderNumber(int customOrderNumber)
        {
            return dbContext.CustomOrders.FirstOrDefault(x => x.CustomOrderNumber == customOrderNumber);
        }

    }
}
