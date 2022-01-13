using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrder
    {
        public static List<string> OrderDisplayPropertyNames = new List<string>
        {
            "CustomOrderNumber", "Debtor", "Reference", "Remarks"
        };

        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "CustomOrderNumber", "CreateDate", "Remarks"
        };

        public static CustomOrder Create(int customOrderNumber, string debtor = "", string reference = "", string remarks = "")
        {
            var dbContext = new SpecificationsDatabaseModel();
            var newCO = new CustomOrder()
            {
                CustomOrderNumber = customOrderNumber,
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
            if (BCustomOrder.ByCustomOrderNumber(customOrder.CustomOrderNumber) != null)
            {
                MessageBox.Show("Creation failed. Order number already exists.");
                return null;
            }

            var dbContext = new SpecificationsDatabaseModel();
            dbContext.CustomOrders.Add(customOrder);
            dbContext.SaveChanges();
            return customOrder;
        }

        public static void Update(CustomOrder customOrder)
        {
            var dbContext = new SpecificationsDatabaseModel();
            var toUpdate = dbContext.CustomOrders.Find(customOrder.ID);
            if (toUpdate != null)
            {
                customOrder.ID = toUpdate.ID;
                dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrder);
                dbContext.SaveChanges();
            }
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
            var copiedCustomOrder = Create(entity);
            BCustomOrderVenilatorTest.Create(copiedCustomOrder);
            return copiedCustomOrder;
        }

        public static bool Validate(CustomOrder customOrder)
        {
            if (customOrder == null)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return false;
            }
            return true;
        }

        public static CustomOrder CreateObject(List<DataGridViewRow> rows)
        {
            var customOrder = new CustomOrder();

            var customOrderNumber = rows.First(x => x.Cells["Description"].Value.ToString().Equals("CustomOrderNumber")).Cells["Value"].Value;
            if (!int.TryParse(customOrderNumber?.ToString(), out int value))
                return null;

            customOrder.CustomOrderNumber = value;

            var debtor = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Debtor")).Cells["Value"].Value;
            customOrder.Debtor = debtor == null ? "" : debtor.ToString();

            var reference = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Reference")).Cells["Value"].Value;
            customOrder.Reference = reference == null ? "" : reference.ToString();

            var remarks = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Remarks")).Cells["Value"].Value;
            customOrder.Remarks = remarks == null ? "" : remarks.ToString();

            return customOrder;
        }
    }
}
