using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorSpeedTests
    {
        [Test]
        public void TestTwoSpeedVentilatorShowsAllRPMOptions()
        {
            // Test order 20502926: RAX 900-10/18"-4/8 with a two speed motor
            var ventilator = new CustomOrderVentilator { HighRPM = 1440, LowRPM = 710 };

            Assert.That(ventilator.IsSingleSpeed(), Is.False);
        }

        [Test]
        public void TestSingleSpeedVentilatorShowsSingleRPMOptions()
        {
            // Test order 20502926: RAX 355-7/17"-2 with a single speed motor
            var ventilator = new CustomOrderVentilator { HighRPM = 2790, LowRPM = null };

            Assert.That(ventilator.IsSingleSpeed(), Is.True);
        }

        [Test]
        public void TestVentilatorWithoutAnyRPMIsSingleSpeed()
        {
            var ventilator = new CustomOrderVentilator();

            Assert.That(ventilator.IsSingleSpeed(), Is.True);
        }
    }
}
