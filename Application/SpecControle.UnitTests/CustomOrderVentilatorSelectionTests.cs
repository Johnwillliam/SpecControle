using Application.Business;
using Infrastructure.Models;

namespace SpecControle.UnitTests
{
    public class CustomOrderVentilatorSelectionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetSelectedVentilatorReturnsFirstWhenIdIsZero()
        {
            var ventilators = new List<CustomOrderVentilator>
            {
                new() { ID = 1 },
                new() { ID = 2 }
            };

            var result = BCustomOrderVentilator.GetSelected(ventilators, 0);

            Assert.That(result, Is.SameAs(ventilators[0]));
        }

        [Test]
        public void TestGetSelectedVentilatorReturnsMatchingId()
        {
            var ventilators = new List<CustomOrderVentilator>
            {
                new() { ID = 1 },
                new() { ID = 2 }
            };

            var result = BCustomOrderVentilator.GetSelected(ventilators, 2);

            Assert.That(result, Is.SameAs(ventilators[1]));
        }

        [Test]
        public void TestGetSelectedVentilatorReturnsNullWhenIdNotFound()
        {
            var ventilators = new List<CustomOrderVentilator>
            {
                new() { ID = 1 },
                new() { ID = 2 }
            };

            var result = BCustomOrderVentilator.GetSelected(ventilators, 999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetSelectedVentilatorReturnsNullForEmptyCollection()
        {
            var ventilators = new List<CustomOrderVentilator>();

            var result = BCustomOrderVentilator.GetSelected(ventilators, 0);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetSelectedVentilatorTestReturnsFirstWhenIdIsZero()
        {
            var tests = new List<CustomOrderVentilatorTest>
            {
                new() { ID = 10 },
                new() { ID = 20 }
            };

            var result = BCustomOrderVentilatorTest.GetSelected(tests, 0);

            Assert.That(result, Is.SameAs(tests[0]));
        }

        [Test]
        public void TestGetSelectedVentilatorTestReturnsMatchingId()
        {
            var tests = new List<CustomOrderVentilatorTest>
            {
                new() { ID = 10 },
                new() { ID = 20 }
            };

            var result = BCustomOrderVentilatorTest.GetSelected(tests, 20);

            Assert.That(result, Is.SameAs(tests[1]));
        }

        [Test]
        public void TestGetSelectedVentilatorTestReturnsNullForStaleId()
        {
            // Regression test: after switching to a different ventilator, a previously
            // selected test ID that no longer exists on this ventilator must resolve to
            // null instead of throwing, so callers can show a friendly message.
            var tests = new List<CustomOrderVentilatorTest>
            {
                new() { ID = 10 },
                new() { ID = 20 }
            };

            var result = BCustomOrderVentilatorTest.GetSelected(tests, 999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetSelectedVentilatorTestReturnsNullForEmptyCollection()
        {
            var tests = new List<CustomOrderVentilatorTest>();

            var result = BCustomOrderVentilatorTest.GetSelected(tests, 0);

            Assert.That(result, Is.Null);
        }
    }
}
