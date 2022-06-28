using EntityFrameworkModel;
using NUnit.Framework;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    public class CustomOrderVentilatorTests
    {
        [Test]
        public void ValidateCustomOrderVentilator()
        {
            // Arrange
            var customOrder = new CustomOrderBuilder().Build();

            var customOrderMotor = new CustomOrderMotorBuilder().Build();

            var customerOrderVentilator = new CustomOrderVentilatorBuilder()
                .WithCustomOrderMotor(customOrderMotor)
                .WithCustomOrder(customOrder)
                .Build();

            // Act
            var result = BCustomOrderVentilator.Validate(customerOrderVentilator);

            // Assert
            Assert.Equals(true, result);
        }
    }
}