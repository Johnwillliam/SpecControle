using EntityFrameworkModel;
using NUnit.Framework;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    public class CustomOrderMotorTests
    {
        [Test]
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