using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorTestSerialNumberTests
    {
        [Test]
        public void TestSerialNumberForSingleTestUsesIndexOne()
        {
            var order = CreateOrder(customOrderNumber: 1234, year: 2026);
            var ventilator = CreateVentilator(order);
            var test = CreateTest(ventilator);

            Assert.That(test.SerialNumber, Is.EqualTo("1234/001/2026"));
        }

        [Test]
        public void TestSerialNumberIncrementsPerTestOnSameVentilator()
        {
            var order = CreateOrder(customOrderNumber: 1234, year: 2026);
            var ventilator = CreateVentilator(order);
            var firstTest = CreateTest(ventilator);
            var secondTest = CreateTest(ventilator);

            Assert.That(firstTest.SerialNumber, Is.EqualTo("1234/001/2026"));
            Assert.That(secondTest.SerialNumber, Is.EqualTo("1234/002/2026"));
        }

        [Test]
        public void TestSerialNumberIndexContinuesAcrossVentilatorsInOrder()
        {
            var order = CreateOrder(customOrderNumber: 5678, year: 2025);
            var firstVentilator = CreateVentilator(order);
            var secondVentilator = CreateVentilator(order);
            CreateTest(firstVentilator);
            var testOnSecondVentilator = CreateTest(secondVentilator);

            Assert.That(testOnSecondVentilator.SerialNumber, Is.EqualTo("5678/002/2025"));
        }

        private static CustomOrder CreateOrder(int customOrderNumber, int year)
        {
            return new CustomOrder
            {
                CustomOrderNumber = customOrderNumber,
                CreateDate = new DateTime(year, 1, 1)
            };
        }

        private static CustomOrderVentilator CreateVentilator(CustomOrder order)
        {
            var ventilator = new CustomOrderVentilator { CustomOrder = order };
            order.CustomOrderVentilators.Add(ventilator);
            return ventilator;
        }

        private static CustomOrderVentilatorTest CreateTest(CustomOrderVentilator ventilator)
        {
            var test = new CustomOrderVentilatorTest { CustomOrderVentilator = ventilator };
            ventilator.CustomOrderVentilatorTests.Add(test);
            return test;
        }
    }
}
