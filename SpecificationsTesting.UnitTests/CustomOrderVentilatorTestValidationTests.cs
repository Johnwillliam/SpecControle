using EntityFrameworkModel;
using Moq;
using NUnit.Framework.Internal;
using SpecificationsTesting.Business;

namespace SpecificationsTestingTests
{
    public class CustomOrderVentilatorTestValidationTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidateForPrintingMeasuredBladeAngleEmpty()
        {
            var ventilatorTest = new Mock<CustomOrderVentilatorTest>();
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest.Object);
            var expectedValidationMessage = "Measured blade angle not filled in.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrintingMeasuredVentilatorHighRPMEmpty()
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
        public void TestValidateForPrintingMeasuredVentilatorLowRPMEmpty()
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
        public void TestValidateForPrintingMeasuredMotorHighRPMEmpty()
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
        public void TestValidateForPrintingMeasuredMotorLowRPMEmpty()
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
        public void TestValidateForPrintingMotorHighRpmEmpty()
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
        public void TestValidateForPrintingVentilatorHighRpmEmpty()
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
        public void TestValidateForPrintingNoMotor()
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
            var expectedValidationMessage = "No motor found, please check configuration.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [Test]
        public void TestValidateForPrintingMeasuredBladeDoesNotMatch()
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
        public void TestValidateForPrintingMeasuredAmpI1HigherThanNominal()
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
        public void TestValidateForPrintingMeasuredAmpI2HigherThanNominal()
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
        public void TestValidateForPrintingMeasuredAmpI3HigherThanNominal()
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
        public void TestValidateForPrintingMeasuredMotorRpmLowerThanNominal()
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
        public void TestValidateForPrintingMeasuredVentilatorHighRpmDiffersMoreThanSpec()
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
                MeasuredVentilatorHighRPM = 10,
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