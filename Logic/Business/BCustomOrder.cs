using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BCustomOrder
    {
        private static readonly List<string> _orderDisplayPropertyNames = new List<string>
        {
            "CustomOrderNumber", "Debtor", "Reference", "Remarks"
        };
        public static readonly List<string> OrderDisplayPropertyNames = _orderDisplayPropertyNames;

        private static readonly List<string> _controleDisplayPropertyNames = new List<string>
        {
            "CustomOrderNumber", "CreateDate", "Remarks"
        };

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static CustomOrder Create(int customOrderNumber, string debtor = "", string reference = "", string remarks = "")
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var newCO = new CustomOrder()
                {
                    CustomOrderNumber = customOrderNumber,
                    Debtor = debtor,
                    Reference = reference,
                    Remarks = remarks,
                    CreateDate = DateTime.Now
            };
                dbContext.CustomOrders.Add(newCO);
                dbContext.SaveChanges();
                return newCO;
            }
        }

        public static CustomOrder Create(CustomOrder customOrder)
        {
            if (BCustomOrder.ByCustomOrderNumber(customOrder.CustomOrderNumber) != null)
            {
                MessageBox.Show("Creation failed. Order number already exists.");
                return null;
            }

            customOrder.CreateDate = DateTime.Now;

            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrders.Add(customOrder);
                dbContext.SaveChanges();
            }
            return customOrder;
        }

        public static void Update(CustomOrder customOrder)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var toUpdate = dbContext.CustomOrders.Find(customOrder.ID);
                if (toUpdate != null)
                {
                    if (customOrder.CreateDate == null)
                        customOrder.CreateDate = DateTime.Now;

                    customOrder.ID = toUpdate.ID;
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrder);
                    dbContext.SaveChanges();
                }
            }
        }

        public static CustomOrder ByCustomOrderNumber(int customOrderNumber)
        {
            var dbContext = new SpecificationsDatabaseModel();
            return dbContext.CustomOrders.Any(x => x.CustomOrderNumber == customOrderNumber) ? dbContext.CustomOrders.Include(x => x.CustomOrderVentilators).ThenInclude(y => y.CustomOrderVentilatorTests)
                                                                                                                        .Include(x => x.CustomOrderVentilators).ThenInclude(y => y.CustomOrderMotor)
                                                                                                                            .Single(z => z.CustomOrderNumber == customOrderNumber) : null;
        }

        public static CustomOrder ByID(int id)
        {
            var dbContext = new SpecificationsDatabaseModel();
            return dbContext.CustomOrders.Any(x => x.ID == id) ? dbContext.CustomOrders.Include(x => x.CustomOrderVentilators).ThenInclude(y => y.CustomOrderVentilatorTests)
                                                                                         .Include(x => x.CustomOrderVentilators).ThenInclude(y => y.CustomOrderMotor)
                                                                                            .Single(z => z.ID == id) : null;
        }

        public static CustomOrder Copy(int id, int customOrderNumber)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var entity = dbContext.CustomOrders.AsNoTracking()
                          .Include(x => x.CustomOrderVentilators)
                          .ThenInclude(x => x.CustomOrderMotor)
                          .FirstOrDefault(x => x.ID == id);

                entity.CustomOrderNumber = customOrderNumber;
                entity.ID = 0;
                entity.CustomOrderVentilators.ToList().ForEach(c => c.ID = 0);
                entity.CustomOrderVentilators.Select(x => x.CustomOrderMotor).ToList().ForEach(c => c.ID = 0);
                var copiedCustomOrder = Create(entity);
                if (copiedCustomOrder != null)
                    BCustomOrderVentilatorTest.Create(copiedCustomOrder);

                return copiedCustomOrder;
            }
        }

        public static bool Validate(CustomOrder customOrder)
        {
            if (customOrder == null || customOrder.CustomOrderNumber == -1)
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
