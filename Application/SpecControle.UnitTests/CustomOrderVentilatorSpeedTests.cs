using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorSpeedTests
    {
        [Test]
        public void TestTwoSpeedVentilatorShowsAllRPMOptions()
        {
            // Testorder 20502926: RAX 900-10/18"-4/8 met 2 toeren motor
            var ventilator = new CustomOrderVentilator { HighRPM = 1440, LowRPM = 710 };

            Assert.That(ventilator.IsSingleSpeed(), Is.False);
        }

        [Test]
        public void TestSingleSpeedVentilatorShowsSingleRPMOptions()
        {
            // Testorder 20502926: RAX 355-7/17"-2 met 1 toerige motor
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
