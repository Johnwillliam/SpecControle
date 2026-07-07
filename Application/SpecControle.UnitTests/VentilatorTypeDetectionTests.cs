using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class VentilatorTypeDetectionTests
    {
        [TestCase("Centrifugal fans direct driven", true)]
        [TestCase("Axial fan direct driven", true)]
        [TestCase("No Indication", false)]
        [TestCase("Thrust fan", false)]
        [TestCase("Centrifugal fan V-belt driven", false)]
        [TestCase("Axial fan V-belt driven", false)]
        [TestCase(null, false)]
        public void TestVentilatorTypeIsDirectDriven(string description, bool expectedResult)
        {
            var ventilatorType = new VentilatorType { Description = description };
            Assert.That(ventilatorType.IsDirectDriven(), Is.EqualTo(expectedResult));
        }

        [TestCase("Centrifugal fans direct driven", true)]
        [TestCase("Axial fan direct driven", true)]
        [TestCase("No Indication", false)]
        [TestCase("Thrust fan", false)]
        [TestCase("Centrifugal fan V-belt driven", false)]
        [TestCase("Axial fan V-belt driven", false)]
        public void TestCustomOrderVentilatorIsDirectDriven(string description, bool expectedResult)
        {
            var ventilator = new CustomOrderVentilator
            {
                VentilatorTypeID = 1,
                VentilatorType = new VentilatorType { ID = 1, Description = description }
            };
            Assert.That(ventilator.IsDirectDriven(), Is.EqualTo(expectedResult));
        }

        [TestCase("Centrifugal fans direct driven", true)]
        [TestCase("Axial fan direct driven", true)]
        [TestCase("No Indication", true)]
        [TestCase("Thrust fan", true)]
        [TestCase("Centrifugal fan V-belt driven", false)]
        [TestCase("Axial fan V-belt driven", false)]
        public void TestCustomOrderVentilatorIsDirectBelt(string description, bool expectedResult)
        {
            var ventilator = new CustomOrderVentilator
            {
                VentilatorTypeID = 1,
                VentilatorType = new VentilatorType { ID = 1, Description = description }
            };
            Assert.That(ventilator.IsDirectBelt(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestCustomOrderVentilatorWithoutTypeIsNotDirectDriven()
        {
            var ventilator = new CustomOrderVentilator();
            Assert.That(ventilator.IsDirectDriven(), Is.False);
        }
    }
}
