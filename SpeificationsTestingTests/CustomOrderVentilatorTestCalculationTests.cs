using NUnit.Framework.Internal;
using SpecificationsTesting.Business;

namespace SpeificationsTestingTests
{
    public class CustomOrderVentilatorTestCalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1500, 50, 1500)]
        [TestCase(1501, 50, 3000)]
        [TestCase(1462, 50, 1500)]
        [TestCase(1420, 50, 1500)]

        [TestCase(750, 50, 750)]
        [TestCase(751, 50, 1000)]
        [TestCase(738, 50, 750)]
        public void TestCalculateSyncRPM(int measuredMotorHighRPM, int customOrderMotorFrequency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilatorTest.CalculateSyncRPM(measuredMotorHighRPM, customOrderMotorFrequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1420, 1420, 1419, 13, true)]
        [TestCase(1420, 1420, 1420, 1420, false)]
        [TestCase(1420, 1420, 1463, 1420, false)]
        public void TestMeasuredVentilatorRPMIsInSpec(int? customOrderMotorHighRPM, int? customOrderVentilatorHighRPM, int measuredMotorHighRPM, int measuredVentilatorHighRPM, bool expectedResult)
        {
            var result = BCustomOrderVentilatorTest.MeasuredVentilatorRPMIsInSpec(customOrderMotorHighRPM, customOrderVentilatorHighRPM, measuredMotorHighRPM, measuredVentilatorHighRPM);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}