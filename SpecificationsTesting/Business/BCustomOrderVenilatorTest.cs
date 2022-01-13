using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using EntityFrameworkModel;

namespace SpecificationsTesting.Business
{
    public class BCustomOrderVenilatorTest
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
                    BCustomOrderVenilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilatorID = ventilator.ID });
                }
            }
        }

        public static void Create(CustomOrderVentilator customOrderVentilator)
        {
            for (int i = 0; i < customOrderVentilator.Amount; i++)
            {
                BCustomOrderVenilatorTest.Create(new CustomOrderVentilatorTest() { CustomOrderVentilator = customOrderVentilator });
            }
        }
    }
}
