using EntityFrameworkModel;
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
                ValidateAmperage(test);
                return true;
            }
            MessageBox.Show($"Test ID {test.ID}: {validationMessage}");
            return false;
        }

        private static void ValidateAmperage(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage != null && test.CustomOrderVentilator.CustomOrderMotor.LowAmperage != null)
            {
                var iLows = new List<decimal?>() { test.I1Low, test.I2Low, test.I3Low };
                var iHighs = new List<decimal?>() { test.I1High, test.I2High, test.I3High };
                var max = iHighs.Max();
                var min = iLows.Min();
                var difference = (decimal)(max / min);
                if (max != null && min != null && difference > 1.05m)
                {
                    MessageBox.Show($"Test ID {test.ID}: The difference between the highest and lowest amperage is more than 5%.");
                }
            }
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
