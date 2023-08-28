using EntityFrameworkModelV2.Models;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BValidateMessage
    {
        public static bool ValidateForPrinting(CustomOrderVentilator ventilator, bool showMessage = true)
        {
            foreach (CustomOrderVentilatorTest test in ventilator.CustomOrderVentilatorTests)
            {
                if (!ValidateForPrinting(test, showMessage))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidateForPrinting(CustomOrderVentilatorTest test, bool showMessage = true)
        {
            var validationMessage = BCustomOrderVentilatorTest.ValidateForPrinting(test);
            if (string.IsNullOrEmpty(validationMessage) && showMessage)
            {
                var amperageValidation = ValidateAmperage(test);
                if (amperageValidation.HasValue && !amperageValidation.Value)
                {
                    MessageBox.Show($"Test ID {test.ID}: The difference between the highest and lowest amperage is more than 5%.");
                }
                else if (!amperageValidation.HasValue)
                {
                    MessageBox.Show($"Test ID {test.ID}: One of the measured amperage is higher than the nominal amperage, overload!");
                }
                return true;
            }

            if (showMessage)
            {
                MessageBox.Show($"Test ID {test.ID}: {validationMessage}");
                return false;
            }

            return string.IsNullOrEmpty(validationMessage);
        }

        public static bool? ValidateAmperage(CustomOrderVentilatorTest test)
        {
            if (test.CustomOrderVentilator.CustomOrderMotor.HighAmperage != null && test.CustomOrderVentilator.CustomOrderMotor.LowAmperage != null)
            {
                var iHighs = new List<decimal?>() { test.I1High, test.I2High, test.I3High };
                var maxHighs = iHighs.Max();
                var minHighs = iHighs.Min();
                if (maxHighs > 0)
                {
                    var differenceHighs = (decimal)((minHighs - maxHighs) / maxHighs) * 100;
                    if (maxHighs != null && minHighs != null && Math.Abs(differenceHighs) > 5)
                    {
                        return false;
                    }
                }

                var iLows = new List<decimal?>() { test.I1Low, test.I2Low, test.I3Low };
                var maxLows = iLows.Max();
                var minLows = iLows.Min();
                if (maxLows > 0)
                {
                    var differenceLows = (decimal)((minLows - maxLows) / maxLows) * 100;
                    if (maxLows != null && minLows != null && Math.Abs(differenceLows) > 5)
                    {
                        return false;
                    }
                }

                if (test.I1High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I2High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage || test.I3High > test.CustomOrderVentilator.CustomOrderMotor.HighAmperage)
                {
                    return null;
                }
            }
            return true;
        }

        public static bool Validate(CustomOrderVentilatorTest test)
        {
            var validationErrors = new List<string>();

            if (test.CustomOrderVentilator.BladeAngle == null)
            {
                validationErrors.Add("Ventilator blade angle not filled in.");
            }
            if (test.MeasuredBladeAngle == null)
            {
                validationErrors.Add("Measured blade angle not filled in.");
            }
            if (test.CustomOrderVentilator.BladeAngle != null && test.MeasuredBladeAngle != null && test.CustomOrderVentilator.BladeAngle.Value != test.MeasuredBladeAngle.Value)
            {
                validationErrors.Add("Measured blade angle does not correspond to the ventilator data. Please check.");
            }
            if (string.IsNullOrWhiteSpace(test.MotorNumber))
            {
                validationErrors.Add("Motornumber not filled in.");
            }
            if (test.MeasuredMotorHighRPM == null)
            {
                validationErrors.Add("Motor High RPM not filled in.");
            }
            if (test.MeasuredVentilatorHighRPM == null)
            {
                validationErrors.Add("Ventilator High RPM not filled in.");
            }

            if (validationErrors.Any())
            {
                MessageBox.Show(string.Join("\n", validationErrors), "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
