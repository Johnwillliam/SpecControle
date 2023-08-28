using EntityFrameworkModelV2.Context;
using EntityFrameworkModelV2.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BCustomOrder
    {
        private static readonly List<string> _orderDisplayPropertyNames = new()
        {
            "CustomOrderNumber", "Debtor", "Reference", "Remarks"
        };
        public static readonly List<string> OrderDisplayPropertyNames = _orderDisplayPropertyNames;

        private static readonly List<string> _controleDisplayPropertyNames = new()
        {
            "CustomOrderNumber", "CreateDate", "Remarks"
        };

        public static List<string> ControleDisplayPropertyNames => _controleDisplayPropertyNames;

        public static CustomOrder Create(int customOrderNumber, string debtor = "", string reference = "", string remarks = "")
        {
            using var dbContext = new SpecificationsDatabaseModel();
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

        public static CustomOrder Create(CustomOrder customOrder)
        {
            if (ByCustomOrderNumber(customOrder.CustomOrderNumber) != null)
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
            using var dbContext = new SpecificationsDatabaseModel();
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

        public static CustomOrder ByCustomOrderNumber(int customOrderNumber)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            return dbContext.CustomOrders
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.CustomOrderVentilatorTests)
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(z => z.CustomOrderMotor)
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.SoundLevelType)
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.TemperatureClass)
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.CatType)
                .SingleOrDefault(x => x.CustomOrderNumber == customOrderNumber);
        }

        public static CustomOrder ById(int id)
        {
            using var dbContext = new SpecificationsDatabaseModel();
            return dbContext.CustomOrders
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.CustomOrderVentilatorTests)
                .Include(x => x.CustomOrderVentilators)
                    .ThenInclude(y => y.CustomOrderMotor)
                .FirstOrDefault(x => x.ID == id);
        }


        public static CustomOrder Copy(int id, int customOrderNumber)
        {
            using var dbContext = new SpecificationsDatabaseModel();
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

        public static bool Validate(CustomOrder customOrder)
        {
            if (customOrder == null || customOrder.CustomOrderNumber == -1)
            {
                MessageBox.Show("Creation failed. Missing data.");
                return false;
            }
            return true;
        }

        public static CustomOrder CreateCustomOrderObject(List<DataGridViewRow> rows)
        {
            var customOrder = new CustomOrder
            {
                CustomOrderNumber = DataGridObjectsUtility.ParseIntValue(rows, nameof(CustomOrder.CustomOrderNumber)),
                Debtor = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrder.Debtor)),
                Reference = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrder.Reference)),
                Remarks = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrder.Remarks))
            };

            return customOrder;
        }
    }
}
