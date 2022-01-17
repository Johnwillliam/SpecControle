using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderVentilatorTest
    {
        public static List<string> ControleDisplayPropertyNames = new List<string>
        {
            "MeasuredVentilatorRPM", "MeasuredMotorRPM", "MeasuredBladeAngle"
        };

        public static CustomOrderVentilatorTest Create(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            var dbContext = new SpecificationsDatabaseModel();
            dbContext.CustomOrderVentilatorTests.Add(customOrderVentilatorTest);
            dbContext.SaveChanges();
            return customOrderVentilatorTest;
        }

        public static void Create(CustomOrder customOrder)
        {
            foreach (var ventilator in customOrder.CustomOrderVentilators)
            {
                for (int i = 0; i < ventilator.Amount; i++)
                {
                    BCustomOrderVentilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = ventilator.ID });
                }
            }
        }

        public static void Create(CustomOrderVentilator customOrderVentilator)
        {
            for (int i = 0; i < customOrderVentilator.Amount; i++)
            {
                BCustomOrderVentilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilator = customOrderVentilator });
            }
        }

        public static void Update(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            var dbContext = new SpecificationsDatabaseModel();
            var toUpdate = dbContext.CustomOrderVentilatorTests.Find(customOrderVentilatorTest.ID);
            if (toUpdate != null)
            {
                dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilatorTest);
                dbContext.SaveChanges();
                Thread.Sleep(300);
            }
        }

        public static CustomOrderVentilatorTest CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderVentilatorTest = new CustomOrderVentilatorTest();

                var measuredVentilatorRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorRPM = DataHelper.ToNullableInt(measuredVentilatorRPM?.ToString());

                var measuredBladeAngle = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredBladeAngle")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredBladeAngle = DataHelper.ToNullableInt(measuredBladeAngle?.ToString());

                var measuredMotorRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorRPM = DataHelper.ToNullableInt(measuredMotorRPM?.ToString());

                return newCustomOrderVentilatorTest;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
