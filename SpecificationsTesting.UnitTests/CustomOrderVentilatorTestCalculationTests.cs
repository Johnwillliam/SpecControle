using Logic.Business;

namespace SpecificationsTestingTests
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

        //to fix
        [TestCase(3015, 50, 0)]
        public void TestCalculateSyncRPM(int measuredMotorHighRPM, int customOrderMotorFrequency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilatorTest.CalculateSyncRPM(measuredMotorHighRPM, customOrderMotorFrequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1420, 1420, 1462, 1462, true)]
        [TestCase(1420, 1420, 1420, 1420, true)]
        [TestCase(1420, 1420, 1463, 1420, false)]
        public void TestMeasuredVentilatorRPMIsInSpec(int? customOrderVentilatorHighRPM, int? customOrderMotorHighRPM, int measuredVentilatorHighRPM, int measuredMotorHighRPM, bool expectedResult)
        {
            var result = BCustomOrderVentilatorTest.MeasuredVentilatorRPMIsInSpec(customOrderMotorHighRPM, customOrderVentilatorHighRPM, measuredMotorHighRPM, measuredVentilatorHighRPM, 3);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}