using Application.Business;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorCalculationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(3000, 4000, 60, 5.56)]
        [TestCase(29182, 578, 75, 6.25)]
        [TestCase(14388, 141, 75, 0.75)]
        [TestCase(44825, 488, 74, 8.21)]
        [TestCase(22213, 120, 74, 1.0)]
        public void TestCalculateShaftPower(decimal airVolume, int? pressureTotal, int? efficiency, decimal? expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateShaftPower(airVolume, pressureTotal, efficiency);
            Assert.That(Math.Round((decimal)result, 2), Is.EqualTo(expectedResult));
        }

        [TestCase(710, 1440, 578, 141)]
        [TestCase(725, 1463, 488, 120)]
        [TestCase(null, 2790, 376, null)]
        [TestCase(null, 2940, 8677, null)]
        public void TestCalculateLowPressureTotal(int? motorLowRPM, int? motorHighRPM, int? highPressureTotal, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(motorLowRPM, motorHighRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureTotal(motorConstant, highPressureTotal);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(710, 1440, 29182, 14388)]
        [TestCase(725, 1463, 44825, 22213)]
        [TestCase(null, 2790, 2520, null)]
        [TestCase(null, 2940, 1675, null)]
        public void TestCalculateLowAirVolume(int? motorLowRPM, int? motorHighRPM, int? highAirVolume, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(motorLowRPM, motorHighRPM);
            var result = BCustomOrderVentilator.CalculateLowAirVolume(motorConstant, highAirVolume);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(710, 1440, 481, 117)]
        [TestCase(725, 1463, 337, 83)]
        [TestCase(null, 2790, 346, null)]
        [TestCase(null, 2940, 8000, null)]
        public void TestCalculateLowPressureStatic(int? lowRPM, int? highRPM, int? highPressureStatic, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowPressureStatic(motorConstant, highPressureStatic);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(710, 1440, 6.25, 0.75)]
        [TestCase(725, 1463, 8.21, 1)]
        [TestCase(null, 2790, 0.462, null)]
        [TestCase(null, 2940, 5.85, null)]
        public void TestCalculateLowShaftPower(int? lowRPM, int? highRPM, decimal? highShaftPower, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateLowShaftPower(motorConstant, highShaftPower);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(700, 1420, 700)]
        public void TestCalculateVBeltLowRPM(int? lowRPM, int? highRPM, decimal? expectedResult)
        {
            var motorConstant = BCustomOrderVentilator.CalculateMotorConstant(lowRPM, highRPM);
            var result = BCustomOrderVentilator.CalculateVBeltLowRPM(motorConstant, highRPM);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(1420, 50, 1500)]
        [TestCase(1463, 50, 1500)]
        [TestCase(2790, 50, 3000)]
        [TestCase(1440, 50, 1500)]
        public void TestCalculateAtexValue(int? highRPM, int? frequency, decimal expectedResult)
        {
            var result = BCustomOrderVentilator.CalculateAtexValue(highRPM, frequency);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}