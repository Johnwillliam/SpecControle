using Application.Business;
using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorLockTests
    {
        [Test]
        public void TestHasLockedTestsReturnsFalseWhenNoTestsAreLocked()
        {
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderVentilatorTests = new List<CustomOrderVentilatorTest>
                {
                    new() { ID = 1, Locked = false },
                    new() { ID = 2, Locked = false }
                }
            };

            Assert.That(BCustomOrderVentilator.HasLockedTests(ventilator), Is.False);
        }

        [Test]
        public void TestHasLockedTestsReturnsTrueWhenAnyTestIsLocked()
        {
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderVentilatorTests = new List<CustomOrderVentilatorTest>
                {
                    new() { ID = 1, Locked = false },
                    new() { ID = 2, Locked = true }
                }
            };

            Assert.That(BCustomOrderVentilator.HasLockedTests(ventilator), Is.True);
        }

        [Test]
        public void TestHasLockedTestsReturnsFalseForVentilatorWithoutTests()
        {
            var ventilator = new CustomOrderVentilator();

            Assert.That(BCustomOrderVentilator.HasLockedTests(ventilator), Is.False);
        }
    }
}
