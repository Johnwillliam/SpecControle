using EntityFrameworkModel;
using NUnit.Framework;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    public class CustomOrderTests
    {
        [Test]
        public void ValidateCustomOrder()
        {
            // Arrange
            var customerOrder = new EntityFrameworkModel.CustomOrder();

            // Act
            var result = BCustomOrder.Validate(customerOrder);

            // Assert
            Assert.Equals(true, result);
        }
    }
}