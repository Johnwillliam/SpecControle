using Application.Business;
using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorPressureValidationTests
    {
        [TestCase(578, 481, 141, 117, true)]
        [TestCase(400, 481, 141, 117, false)]
        [TestCase(578, 481, 100, 117, false)]
        [TestCase(578, 578, 141, 141, true)]
        [TestCase(null, null, null, null, true)]
        [TestCase(578, null, 141, null, true)]
        public void TestHasValidPressures(int? highPressureTotal, int? highPressureStatic, int? lowPressureTotal, int? lowPressureStatic, bool expectedResult)
        {
            var ventilator = new CustomOrderVentilator
            {
                HighPressureTotal = highPressureTotal,
                HighPressureStatic = highPressureStatic,
                LowPressureTotal = lowPressureTotal,
                LowPressureStatic = lowPressureStatic
            };

            Assert.That(BCustomOrderVentilator.HasValidPressures(ventilator), Is.EqualTo(expectedResult));
        }
    }
}
