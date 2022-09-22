using SpecificationsTesting.Business;

namespace SpeificationsTestingTests
{
    public class CustomOrderVentilatorCalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(3000, 4000, 60, 5.556)]
        public void TestCalculateShaftPower(decimal airVolume, int? pressureTotal, int? efficiency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateShaftPower(airVolume, pressureTotal, efficiency);
            Assert.That(Math.Round((decimal)result, 3), Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 404, 98)]
        public void TestCalculateLowPressureTotal(int? lowRPM, int? highRPM, int? highPressureTotal, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureTotal(motorConstant, highPressureTotal);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 17024, 8392)]
        public void TestCalculateLowAirVolume(int? lowRPM, int? highRPM, int? highAirVolume, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowAirVolume(motorConstant, highAirVolume);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 351, 85)]
        public void TestCalculateLowPressureStatic(int? lowRPM, int? highRPM, int? highPressureStatic, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureStatic(motorConstant, highPressureStatic);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 3.03d, 0.36d)]
        public void TestCalculateLowShaftPower(int? lowRPM, int? highRPM, decimal? highShaftPower, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowShaftPower(motorConstant, highShaftPower);
            Assert.That(Math.Round(result, 2), Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 700)]
        public void TestCalculateVBeltLowRPM(int? lowRPM, int? highRPM, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateVBeltLowRPM(motorConstant, highRPM);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1420, 50, 1500)]
        public void TestCalculateAtexValue(int? highRPM, int? frequency, decimal expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateAtexValue(highRPM, frequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}