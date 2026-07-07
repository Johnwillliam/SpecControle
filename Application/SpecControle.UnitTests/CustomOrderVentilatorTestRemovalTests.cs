using Application.Business;
using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorTestRemovalTests
    {
        [Test]
        public void TestRemovesDistinctTestsWhenAmountDropsByMoreThanOne()
        {
            var tests = CreateTests(unlockedIds: [1, 2, 3]);

            var toRemove = BCustomOrderVentilator.SelectTestsToRemove(tests, 2);

            Assert.That(toRemove.Select(x => x.ID), Is.EquivalentTo(new[] { 2, 3 }));
        }

        [Test]
        public void TestLockedTestsAreNeverRemoved()
        {
            var tests = CreateTests(unlockedIds: [1, 3]);
            tests.Insert(1, new CustomOrderVentilatorTest { ID = 2, Locked = true });

            var toRemove = BCustomOrderVentilator.SelectTestsToRemove(tests, 2);

            Assert.That(toRemove.Select(x => x.ID), Is.EquivalentTo(new[] { 1, 3 }));
        }

        [Test]
        public void TestRemovesNoMoreThanTheUnlockedTests()
        {
            var tests = CreateTests(unlockedIds: [1]);
            tests.Add(new CustomOrderVentilatorTest { ID = 2, Locked = true });

            var toRemove = BCustomOrderVentilator.SelectTestsToRemove(tests, 5);

            Assert.That(toRemove.Select(x => x.ID), Is.EquivalentTo(new[] { 1 }));
        }

        private static List<CustomOrderVentilatorTest> CreateTests(int[] unlockedIds)
        {
            return unlockedIds.Select(id => new CustomOrderVentilatorTest { ID = id, Locked = false }).ToList();
        }
    }
}
