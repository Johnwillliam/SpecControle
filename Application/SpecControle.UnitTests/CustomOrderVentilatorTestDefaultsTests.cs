using Application.Business;
using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorTestDefaultsTests
    {
        [Test]
        public void TestBuildSizeIsTakenFromMotorIECWhenEmpty()
        {
            var test = new CustomOrderVentilatorTest();
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = new CustomOrderMotor { IEC = 71 }
            };

            BCustomOrderVentilatorTest.ApplyControleDefaults(test, ventilator);

            Assert.That(test.BuildSize, Is.EqualTo(71));
        }

        [Test]
        public void TestExistingBuildSizeIsNotOverwritten()
        {
            var test = new CustomOrderVentilatorTest { BuildSize = 160 };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = new CustomOrderMotor { IEC = 71 }
            };

            BCustomOrderVentilatorTest.ApplyControleDefaults(test, ventilator);

            Assert.That(test.BuildSize, Is.EqualTo(160));
        }

        [Test]
        public void TestBuildSizeStaysEmptyWithoutMotor()
        {
            var test = new CustomOrderVentilatorTest();
            var ventilator = new CustomOrderVentilator();

            BCustomOrderVentilatorTest.ApplyControleDefaults(test, ventilator);

            Assert.That(test.BuildSize, Is.Null);
        }

        [Test]
        public void TestEmptyDateDefaultsToToday()
        {
            var test = new CustomOrderVentilatorTest();
            var ventilator = new CustomOrderVentilator();

            BCustomOrderVentilatorTest.ApplyControleDefaults(test, ventilator);

            Assert.That(test.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void TestExistingDateIsNotOverwritten()
        {
            var existingDate = new DateTime(2022, 9, 28);
            var test = new CustomOrderVentilatorTest { Date = existingDate };
            var ventilator = new CustomOrderVentilator();

            BCustomOrderVentilatorTest.ApplyControleDefaults(test, ventilator);

            Assert.That(test.Date, Is.EqualTo(existingDate));
        }
    }
}
