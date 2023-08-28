using EntityFrameworkModelV2.Models;
using System.Windows.Forms;

namespace Logic.Business
{
    public static class BCustomOrderVentilatorTestUI
    {
        public static CustomOrderVentilatorTest CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderVentilatorTest = new CustomOrderVentilatorTest
                {
                    MeasuredVentilatorHighRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.MeasuredVentilatorHighRPM)),
                    MeasuredVentilatorLowRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.MeasuredVentilatorLowRPM)),
                    MeasuredBladeAngle = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.MeasuredBladeAngle)),
                    MeasuredMotorHighRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.MeasuredMotorHighRPM)),
                    MeasuredMotorLowRPM = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.MeasuredMotorLowRPM)),
                    Cover = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.Cover)),
                    I1High = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I1High)),
                    I1Low = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I1Low)),
                    I2High = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I2High)),
                    I2Low = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I2Low)),
                    I3High = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I3High)),
                    I3Low = DataGridObjectsUtility.ParseNullableDecimalValue(rows, nameof(CustomOrderVentilatorTest.I3Low)),
                    MotorNumber = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderVentilatorTest.MotorNumber)),
                    Weight = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.Weight))
                };
                var date = DataGridObjectsUtility.ParseStringValue(rows, nameof(CustomOrderVentilatorTest.Date));
                newCustomOrderVentilatorTest.Date = string.IsNullOrEmpty(date) ? null : DateTime.Parse(date);
                newCustomOrderVentilatorTest.BuildSize = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.BuildSize));

                // Set default values
                newCustomOrderVentilatorTest.I2High ??= newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I3High ??= newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I2Low ??= newCustomOrderVentilatorTest.I1Low;
                newCustomOrderVentilatorTest.I3Low ??= newCustomOrderVentilatorTest.I1Low;

                return newCustomOrderVentilatorTest;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
