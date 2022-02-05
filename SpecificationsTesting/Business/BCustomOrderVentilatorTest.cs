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
                BCustomOrderVentilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = customOrderVentilator.ID });
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

        public static bool Validate(CustomOrderVentilatorTest test)
        {
            if(test.CustomOrderVentilator.BladeAngle.Value != test.MeasuredBladeAngle.Value)
            {
                MessageBox.Show("Measured blade angle does not correspond the ventilator data. Please check.");
                return false;
            }
            if(test.MotorNumber == null)
            {
                MessageBox.Show("");
                return false;
            }
            if(test.MeasuredMotorHighRPM == null || test.MeasuredMotorLowRPM == null)
            {
                MessageBox.Show("");
                return false;
            }
            if (test.MeasuredVentilatorHighRPM == null || test.MeasuredVentilatorLowRPM == null)
            {
                MessageBox.Show("");
                return false;
            }
            if (test.MeasuredBladeAngle == null)
            {
                MessageBox.Show("");
                return false;
            }
            if (test.MeasuredVentilatorHighRPM > test.CustomOrderVentilator.CustomOrderMotor.HighRPM || test.MeasuredMotorLowRPM > test.CustomOrderVentilator.CustomOrderMotor.LowRPM)
            {
                MessageBox.Show("");
                return false;
            }
            return true;
        }

        public static CustomOrderVentilatorTest CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderVentilatorTest = new CustomOrderVentilatorTest();

                var measuredVentilatorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorHighRPM = DataHelper.ToNullableInt(measuredVentilatorHighRPM?.ToString());

                var measuredVentilatorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorLowRPM = DataHelper.ToNullableInt(measuredVentilatorLowRPM?.ToString());

                var measuredBladeAngle = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredBladeAngle")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredBladeAngle = DataHelper.ToNullableInt(measuredBladeAngle?.ToString());

                var measuredMotorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorHighRPM = DataHelper.ToNullableInt(measuredMotorHighRPM?.ToString());

                var measuredMotorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorLowRPM = DataHelper.ToNullableInt(measuredMotorLowRPM?.ToString());

                var cover = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Cover")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Cover = DataHelper.ToNullableInt(cover?.ToString());

                var l1 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L1")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L1 = l1?.ToString();

                var l2 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L2")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L2 = l2?.ToString();

                var l3 = rows.First(x => x.Cells["Description"].Value.ToString().Equals("L3")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.L3 = l3?.ToString();

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
