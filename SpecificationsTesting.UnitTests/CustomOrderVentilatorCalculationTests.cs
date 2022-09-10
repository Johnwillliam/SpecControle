using SpecificationsTesting.Business;

namespace SpeificationsTestingTests
{
    public class CustomOrderVentilatorCalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(3000, 4000, 60, 5.5555555555555555555555555555d)]
        public void TestCalculateShaftPower(decimal airVolume, int? pressureTotal, int? efficiency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateShaftPower(airVolume, pressureTotal, efficiency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1021, 10, 10, 10)]
        public void TestCalculateLowPressureTotal(int? lowRPM, int? highRPM, int? highPressureTotal, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureTotal(motorConstant, highPressureTotal);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10, 10)]
        public void TestCalculateLowAirVolume(int? lowRPM, int? highRPM, int? highAirVolume, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowAirVolume(motorConstant, highAirVolume);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10, 10)]
        public void TestCalculateLowPressureStatic(int? lowRPM, int? highRPM, int? highPressureStatic, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureStatic(motorConstant, highPressureStatic);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10, 10)]
        public void TestCalculateLowShaftPower(int? lowRPM, int? highRPM, int? highShaftPower, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowShaftPower(motorConstant, highShaftPower);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10)]
        public void TestCalculateVBeltLowRPM(int? lowRPM, int? highRPM, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateVBeltLowRPM(motorConstant, highRPM);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10)]
        public void TestCalculateAtexValue(int? highRPM, int? frequency, decimal expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateAtexValue(highRPM, frequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}