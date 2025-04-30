using System.Globalization;
using System.Windows.Forms;
using Application.Business;
using Infrastructure.Models;

namespace Application.Business
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
                newCustomOrderVentilatorTest.Date = DateTime.TryParse(date, out var dateResult) ? dateResult : DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                newCustomOrderVentilatorTest.BuildSize = DataGridObjectsUtility.ParseNullableIntValue(rows, nameof(CustomOrderVentilatorTest.BuildSize));

                // Set default values
                newCustomOrderVentilatorTest.I2High = newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I3High = newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I2Low = newCustomOrderVentilatorTest.I1Low;
                newCustomOrderVentilatorTest.I3Low = newCustomOrderVentilatorTest.I1Low;

                return newCustomOrderVentilatorTest;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
