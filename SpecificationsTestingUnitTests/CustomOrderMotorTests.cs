using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    [TestFixture]
    public class CustomOrderMotorTests
    {
        [TestMethod]
        public void ValidateCustomOrderMotor()
        {
            // Arrange
            var customerOrderMotor = new EntityFrameworkModel.CustomOrderMotor();

            // Act
            var result = BCustomOrderMotor.Validate(customerOrderMotor);

            // Assert
            Assert.Equals(true, result);
        }
    }
}