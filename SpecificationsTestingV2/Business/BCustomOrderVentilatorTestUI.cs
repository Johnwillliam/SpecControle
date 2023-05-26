using EntityFrameworkModelV2.Models;

namespace SpecificationsTesting.Business
{
    public static class BCustomOrderVentilatorTestUI
    {
        public static CustomOrderVentilatorTest CreateObject(List<DataGridViewRow> rows)
        {
            try
            {
                var newCustomOrderVentilatorTest = new CustomOrderVentilatorTest();

                var measuredVentilatorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorHighRPM = DataHelper.ToNullableInt(measuredVentilatorHighRPM?.ToString());

                var measuredVentilatorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredVentilatorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredVentilatorLowRPM = DataHelper.ToNullableInt(measuredVentilatorLowRPM?.ToString());

                var measuredBladeAngle = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredBladeAngle")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredBladeAngle = DataHelper.ToNullableInt(measuredBladeAngle?.ToString());

                var measuredMotorHighRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorHighRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorHighRPM = DataHelper.ToNullableInt(measuredMotorHighRPM?.ToString());

                var measuredMotorLowRPM = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MeasuredMotorLowRPM")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MeasuredMotorLowRPM = DataHelper.ToNullableInt(measuredMotorLowRPM?.ToString());

                var cover = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Cover")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Cover = DataHelper.ToNullableInt(cover?.ToString());

                var i1High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I1High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I1High = DataHelper.ToNullableDecimal(i1High?.ToString());

                var i1Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I1Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I1Low = DataHelper.ToNullableDecimal(i1Low?.ToString());

                var i2High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2High = DataHelper.ToNullableDecimal(i2High?.ToString());

                var i2Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I2Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I2Low = DataHelper.ToNullableDecimal(i2Low?.ToString());

                var i3High = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3High")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3High = DataHelper.ToNullableDecimal(i3High?.ToString());

                var i3Low = rows.First(x => x.Cells["Description"].Value.ToString().Equals("I3Low")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.I3Low = DataHelper.ToNullableDecimal(i3Low?.ToString());

                var motorNumber = rows.First(x => x.Cells["Description"].Value.ToString().Equals("MotorNumber")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.MotorNumber = motorNumber?.ToString();

                var weight = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Weight")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Weight = DataHelper.ToNullableInt(weight?.ToString());

                var date = rows.First(x => x.Cells["Description"].Value.ToString().Equals("Date")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.Date = string.IsNullOrEmpty(date.ToString()) ? (DateTime?)null : DateTime.Parse(date.ToString());

                var buildSize = rows.First(x => x.Cells["Description"].Value.ToString().Equals("BuildSize")).Cells["Value"].Value;
                newCustomOrderVentilatorTest.BuildSize = DataHelper.ToNullableInt(buildSize?.ToString());

                newCustomOrderVentilatorTest.I2High = newCustomOrderVentilatorTest.I2High ?? newCustomOrderVentilatorTest.I1High;
                newCustomOrderVentilatorTest.I3High = newCustomOrderVentilatorTest.I3High ?? newCustomOrderVentilatorTest.I1High;

                newCustomOrderVentilatorTest.I2Low = newCustomOrderVentilatorTest.I2Low ?? newCustomOrderVentilatorTest.I1Low;
                newCustomOrderVentilatorTest.I3Low = newCustomOrderVentilatorTest.I3Low ?? newCustomOrderVentilatorTest.I1Low;

                return newCustomOrderVentilatorTest;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
