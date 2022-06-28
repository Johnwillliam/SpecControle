using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    [TestFixture]
    public class CustomOrderTests
    {
        [TestMethod]
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