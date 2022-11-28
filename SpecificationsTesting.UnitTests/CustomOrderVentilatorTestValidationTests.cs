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

        //[Test]
        //public void TestValidateForPrintingMeasuredVentilatorLowRPMEmpty()
        //{
        //    var ventilatorTest = new CustomOrderVentilatorTest
        //    {
        //        MeasuredBladeAngle = 1,
        //        MeasuredVentilatorHighRPM = 1
        //    };
        //    var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
        //    var expectedValidationMessage = "Measured ventilator low RPM not filled in.";
        //    Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        //}

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

        //[Test]
        //public void TestValidateForPrintingMeasuredMotorLowRPMEmpty()
        //{
        //    var ventilatorTest = new CustomOrderVentilatorTest
        //    {
        //        MeasuredBladeAngle = 1,
        //        MeasuredVentilatorHighRPM = 1,
        //        MeasuredVentilatorLowRPM = 1,
        //        MeasuredMotorHighRPM = 1
        //    };
        //    var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
        //    var expectedValidationMessage = "Measured motor low RPM not filled in.";
        //    Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        //}

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

        [TestCase(1462, 738, 1419, 738)]
        public void TestValidateForPrintingMeasuredVentilatorHighRpmDiffersMoreThanSpec(int measuredVentilatorHighRPM, int measuredVentilatorLowRPM, int measuredMotorHighRPM, int measuredMotorLowRPM)
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
                MeasuredVentilatorHighRPM = 1462,
                MeasuredVentilatorLowRPM = 738,
                MeasuredMotorHighRPM = 1419,
                MeasuredMotorLowRPM = 738,
                I1High = 15,
                I2High = 15,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = "The measured ventilator high RPM differs more than 3%.";
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [TestCase(1462, 738, 1420, 738)]
        [TestCase(1462, 700, 1420, 700)]
        public void TestValidateForPrintingMeasuredVentilatorHighRpmDiffersWithinThanSpec(int measuredVentilatorHighRPM, int measuredVentilatorLowRPM, int measuredMotorHighRPM, int measuredMotorLowRPM)
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
                MeasuredVentilatorHighRPM = measuredVentilatorHighRPM,
                MeasuredVentilatorLowRPM = measuredVentilatorLowRPM,
                MeasuredMotorHighRPM = measuredMotorHighRPM,
                MeasuredMotorLowRPM = measuredMotorLowRPM,
                I1High = 15,
                I2High = 15,
                I3High = 15
            };
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(ventilatorTest);
            var expectedValidationMessage = string.Empty;
            Assert.That(validationMessage, Is.EqualTo(expectedValidationMessage));
        }

        [TestCase(10, 10, 10, 10, 10, 10, true)]
        [TestCase(17.50, 17.50, 15, 5.60, 5.60, 5.60, false)]
        [TestCase(17.50, 17.50, 16.62, 5.60, 5.60, 5.60, false)]
        [TestCase(17.50, 17.50, 16.625, 5.60, 5.60, 5.60, true)]
        [TestCase(17.50, 17.50, 17.50, 5.60, 5.60, 5.30, false)]
        [TestCase(17.50, 17.50, 17.50, 5.60, 5.60, 5.315, false)]
        [TestCase(17.50, 17.50, 17.50, 5.60, 5.60, 5.32, true)]
        public void TestValidateAmperage(decimal i1High, decimal i2High, decimal i3High, decimal i1Low, decimal i2Low, decimal i3Low, bool expectedResult)
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 20,
                LowAmperage = 10
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
                I1High = i1High,
                I2High = i2High,
                I3High = i3High,
                I1Low = i1Low,
                I2Low = i2Low,
                I3Low = i3Low
            };

            var result = BValidateMessage.ValidateAmperage(ventilatorTest);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 10, 10, 10, 10, 10, true)]
        [TestCase(17.50, 17.50, 17.50, 5.60, 5.60, 5.60, null)]
        public void TestValidateAmperageOverload(decimal i1High, decimal i2High, decimal i3High, decimal i1Low, decimal i2Low, decimal i3Low, bool? expectedResult)
        {
            var motor = new CustomOrderMotor
            {
                HighAmperage = 15,
                LowAmperage = 10
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
                I1High = i1High,
                I2High = i2High,
                I3High = i3High,
                I1Low = i1Low,
                I2Low = i2Low,
                I3Low = i3Low
            };

            var result = BValidateMessage.ValidateAmperage(ventilatorTest);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}