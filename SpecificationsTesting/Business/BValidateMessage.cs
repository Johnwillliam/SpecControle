using EntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SpecificationsTesting.Business
{
    public static class BValidateMessage
    {
        public static bool ValidateForPrinting(CustomOrderVentilator ventilator)
        {
            foreach (CustomOrderVentilatorTest test in ventilator.CustomOrderVentilatorTests)
            {
                if (!ValidatePrinting(test))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidatePrinting(CustomOrderVentilatorTest test)
        {
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(test);
            if (string.IsNullOrEmpty(validationMessage))
            {
                var amperageValidation = ValidateAmperage(test);
                if(!amperageValidation)
                {
                    MessageBox.Show($"Test ID {test.ID}: The difference between the highest and lowest amperage is more than 5%.");
                }
                return true;
            }
            MessageBox.Show($"Test ID {test.ID}: {validationMessage}");
            return false;
        }

        public static bool ValidateAmperage(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage != null && test.CustomOrderVentilator.CustomOrderMotor.LowAmperage != null)
            {
                var iLows = new List<decimal?>() { test.I1Low, test.I2Low, test.I3Low };
                var iHighs = new List<decimal?>() { test.I1High, test.I2High, test.I3High };
                var maxHighs = iHighs.Max();
                var minHighs = iHighs.Min();
                var maxLows = iLows.Max();
                var minLows = iLows.Min();
                var differenceHighs = (decimal)((minHighs - maxHighs) / maxHighs) * 100;
                var differenceLows = (decimal)((minLows - maxLows) / maxLows) * 100;
                if (maxHighs != null && minHighs != null && Math.Abs(differenceHighs) > 5)
                {
                    return false;
                }
                if (maxLows != null && minLows != null && Math.Abs(differenceLows) > 5)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Validate(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.BladeAngle == null)
            {
                MessageBox.Show("Ventilator blade angle not filled in.");
            }
            if (test.MeasuredBladeAngle == null)
            {
                MessageBox.Show("Measured blade angle not filled in.");
            }
            if (test.CustomOrderVentilator.BladeAngle != null && test.MeasuredBladeAngle != null && test.CustomOrderVentilator.BladeAngle.Value != test.MeasuredBladeAngle.Value)
            {
                MessageBox.Show("Measured blade angle does not correspond the ventilator data. Please check.");
            }
            if (test.MotorNumber == null)
            {
                MessageBox.Show("Motornumber not filled in.");
            }
            if (test.MeasuredMotorHighRPM == null)
            {
                MessageBox.Show("Motor High RPM not filled in.");
            }
            if (test.MeasuredVentilatorHighRPM == null)
            {
                MessageBox.Show("Ventilator High RPM not filled in.");
            }

            return true;
        }
    }
}
