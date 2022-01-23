using System;
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
            "MeasuredVentilatorRPM", "MeasuredMotorRPM", "MeasuredBladeAngle", "Cover",
            "L1", "L2", "L3", "MotorNumber", "Weight", "Date", "UserID"
        };

        public static CustomOrderVentilatorTest Create(CustomOrderVentilatorTest customOrderVentilatorTest)
        {
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                dbContext.CustomOrderVentilatorTests.Add(customOrderVentilatorTest);
                dbContext.SaveChanges();
                return customOrderVentilatorTest;
            }
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
            using (var dbContext = new SpecificationsDatabaseModel())
            {
                var toUpdate = dbContext.CustomOrderVentilatorTests.Find(customOrderVentilatorTest.ID);
                if (toUpdate != null)
                {
                    dbContext.Entry(toUpdate).CurrentValues.SetValues(customOrderVentilatorTest);
                    dbContext.SaveChanges();
                    Thread.Sleep(300);
                }
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

                var cover = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Cover")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Cover = DataHelper.ToNullableInt(cover?.ToString());

                var l1 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L1")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L1 = l1.ToString();

                var l2 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L2")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L2 = l2.ToString(); ;

                var l3 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L3")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L3 = l3.ToString();

                var motorNumber = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MotorNumber")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MotorNumber = DataHelper.ToNullableInt(motorNumber?.ToString());

                var weight = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Weight")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Weight = DataHelper.ToNullableInt(weight?.ToString());

                var date = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Date")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Date = string.IsNullOrEmpty(date.ToString()) ? (DateTime?)null : DateTime.Parse(date.ToString());


                return newCustomOrderVentilatorTest;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
