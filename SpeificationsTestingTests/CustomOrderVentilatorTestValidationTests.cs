using EntityFrameworkModel;
using Moq;
using NUnit.Framework.Internal;
using SpecificationsTesting.Business;

namespace SpeificationsTestingTests
{
    public class CustomOrderVentilatorTestValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidateForPrinting()
        {
            var ventilatorTest = new Mock<CustomOrderVentilatorTest>();
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest.Object);
            var expectedValidationMessage = "Measured blade angle not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting12()
        {
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                MeasuredBladeAngle = 1
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Measured ventilator high RPM not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting13()
        {
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                MeasuredBladeAngle = 1,
                MeasuredVentilatorHighRPM = 1
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Measured ventilator low RPM not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting14()
        {
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                MeasuredBladeAngle = 1,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Measured motor high RPM not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting15()
        {
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                MeasuredBladeAngle = 1,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Measured motor low RPM not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting1()
        {
            var ventilator = new CustomOrderVentilator
            {
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                MeasuredBladeAngle = 20
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Measured blade angle does not matched the ordered angle.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting2()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 20,
                I2High = 15,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "One of the measured amperages is higher than the nominal amperage.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting3()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 20,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "One of the measured amperages is higher than the nominal amperage.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting4()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 15,
                I3High = 20
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "One of the measured amperages is higher than the nominal amperage.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting5()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 15,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Motor high RPM is not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting6()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15,
                HighRPM = 10
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorHighRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 15,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "Ventilator high RPM is not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting8()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15,
                HighRPM = 10
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15,
                HighRPM = 10
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 15,
                I3High = 15,
                MeasuredMotorHighRPM = 5
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "The measured motor RPM is lower than the nominal RPM.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrinting9()
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15,
                HighRPM = 10,
                Frequency = 50
            };
            var ventilator = new CustomOrderVentilator
            {
                CustomOrderMotor = motor,
                BladeAngle = 15,
                HighRPM = 10
            };
            var ventilatorTest = new CustomOrderVentilatorTest
            {
                CustomOrderVentilator = ventilator,
                MeasuredBladeAngle = 15,
                MeasuredVentilatorHighRPM = 1,
                MeasuredVentilatorLowRPM = 1,
                MeasuredMotorLowRPM = 1,
                I1High = 15,
                I2High = 15,
                I3High = 15,
                MeasuredMotorHighRPM = 10
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "The measured ventilator high RPM differs more than 3%.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }
    }
}