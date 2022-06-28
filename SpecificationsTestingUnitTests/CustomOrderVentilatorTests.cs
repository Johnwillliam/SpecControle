using EntityFrameworkModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecificationsTesting.Business;

namespace SpecificationsTestingUnitTests
{
    [TestClass]
    public class CustomOrderVentilatorTests
    {
        [TestMethod]
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
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateCustomOrderVentilatorEfficiencyValid()
        {
            // Arrange
            var customOrder = new CustomOrderBuilder().Build();

            var customOrderMotor = new CustomOrderMotorBuilder().Build();

            var customerOrderVentilator = new CustomOrderVentilatorBuilder()
                .WithCustomOrderMotor(customOrderMotor)
                .WithCustomOrder(customOrder)
                .WithEfficiency(95)
                .Build();

            // Act
            var result = BCustomOrderVentilator.Validate(customerOrderVentilator);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateCustomOrderVentilatorEfficiencyInvalid()
        {
            // Arrange
            var customOrder = new CustomOrderBuilder().Build();

            var customOrderMotor = new CustomOrderMotorBuilder().Build();

            var customerOrderVentilator = new CustomOrderVentilatorBuilder()
                .WithCustomOrderMotor(customOrderMotor)
                .WithCustomOrder(customOrder)
                .WithEfficiency(98)
                .Build();

            // Act
            var result = BCustomOrderVentilator.Validate(customerOrderVentilator);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateCustomOrderVentilatorShaftPowerValid()
        {
            // Arrange
            var customOrder = new CustomOrderBuilder().Build();

            var customOrderMotor = new CustomOrderMotorBuilder()
                .WithHighPower(20)
                .Build();

            var customerOrderVentilator = new CustomOrderVentilatorBuilder()
                .WithCustomOrderMotor(customOrderMotor)
                .WithCustomOrder(customOrder)
                .WithHighShaftPower(15)
                .Build();

            // Act
            var result = BCustomOrderVentilator.Validate(customerOrderVentilator);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateCustomOrderVentilatorShaftPowerInvalid()
        {
            // Arrange
            var customOrder = new CustomOrderBuilder().Build();

            var customOrderMotor = new CustomOrderMotorBuilder()
                .WithHighPower(15)
                .Build();

            var customerOrderVentilator = new CustomOrderVentilatorBuilder()
                .WithCustomOrderMotor(customOrderMotor)
                .WithCustomOrder(customOrder)
                .WithHighShaftPower(20)
                .Build();

            // Act
            var result = BCustomOrderVentilator.Validate(customerOrderVentilator);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void CalculateLowShaftPower()
        {
            // Arrange
            decimal airVolume = 15000;
            int? pressureTotal = 2770;
            int? efficiency = 86;
            decimal? expected = 13.420542635658914728682170543M;

            // Act
            var result = BCustomOrderVentilator.CalculateShaftPower(airVolume, pressureTotal, efficiency);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}