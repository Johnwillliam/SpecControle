using Application.Business;

namespace SpecControle.UnitTests
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
        // Boven de hoogste synchrone verhouding (60) is de synchrone snelheid frequentie x 60
        [TestCase(3015, 50, 3000)]
        public void TestCalculateSyncRPM(int measuredMotorHighRPM, int customOrderMotorFrequency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilatorTest.CalculateSyncRPM(measuredMotorHighRPM, customOrderMotorFrequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1420, 1420, 1462, 1462, true)]
        [TestCase(1420, 1420, 1420, 1420, true)]
        [TestCase(1420, 1420, 1463, 1420, false)]
        // Motor draait boven nominaal: het verwachte ventilatortoerental moet meeschalen
        [TestCase(1463, 1440, 1510, 1481, true)]
        public void TestMeasuredVentilatorRPMIsInSpec(int? customOrderVentilatorHighRPM, int? customOrderMotorHighRPM, int measuredVentilatorHighRPM, int measuredMotorHighRPM, bool expectedResult)
        {
            var result = BCustomOrderVentilatorTest.MeasuredVentilatorRPMIsInSpec(customOrderMotorHighRPM, customOrderVentilatorHighRPM, measuredMotorHighRPM, measuredVentilatorHighRPM, 3);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}