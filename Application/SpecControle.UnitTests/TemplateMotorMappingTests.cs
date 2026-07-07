using Infrastructure.Models;
using SpecControle.UserControls;

namespace SpecControle.UnitTests
{
    public class TemplateMotorMappingTests
    {
        [Test]
        public void TestAllTemplateMotorFieldsSurviveGridRoundTrip()
        {
            var motor = new TemplateMotor
            {
                ID = 7,
                Name = "CANTONI",
                Type = "SG 160L-48/W",
                Version = "MARINE",
                IEC = 160,
                IP = 56,
                PTC = true,
                HT = false,
                BuildingType = "B3",
                ISO = "F",
                HighPower = 11.5m,
                LowPower = 3m,
                HighRPM = 1440,
                LowRPM = 710,
                HighAmperage = 21.4m,
                LowAmperage = 7.1m,
                HighStartupAmperage = 247m,
                LowStartupAmperage = 21m,
                VoltageType = "400/3 YY-Y",
                Frequency = 50,
                Poles = 4,
                PowerFactor = 0.82m,
                Bearings = "6309"
            };

            var table = MotorTemplateUserControl.ConvertToDataTable(new List<TemplateMotor> { motor });
            using var grid = new DataGridView
            {
                BindingContext = new BindingContext(),
                AutoGenerateColumns = true,
                DataSource = table
            };

            var result = MotorTemplateUserControl.CreateTemplateMotorByDataGridViewRow(grid.Rows[0]);

            Assert.Multiple(() =>
            {
                Assert.That(result.ID, Is.EqualTo(motor.ID));
                Assert.That(result.Name, Is.EqualTo(motor.Name));
                Assert.That(result.Type, Is.EqualTo(motor.Type));
                Assert.That(result.Version, Is.EqualTo(motor.Version));
                Assert.That(result.IEC, Is.EqualTo(motor.IEC));
                Assert.That(result.IP, Is.EqualTo(motor.IP));
                Assert.That(result.PTC, Is.EqualTo(motor.PTC));
                Assert.That(result.HT, Is.EqualTo(motor.HT));
                Assert.That(result.BuildingType, Is.EqualTo(motor.BuildingType));
                Assert.That(result.ISO, Is.EqualTo(motor.ISO));
                Assert.That(result.HighPower, Is.EqualTo(motor.HighPower));
                Assert.That(result.LowPower, Is.EqualTo(motor.LowPower));
                Assert.That(result.HighRPM, Is.EqualTo(motor.HighRPM));
                Assert.That(result.LowRPM, Is.EqualTo(motor.LowRPM));
                Assert.That(result.HighAmperage, Is.EqualTo(motor.HighAmperage));
                Assert.That(result.LowAmperage, Is.EqualTo(motor.LowAmperage));
                Assert.That(result.HighStartupAmperage, Is.EqualTo(motor.HighStartupAmperage));
                Assert.That(result.LowStartupAmperage, Is.EqualTo(motor.LowStartupAmperage));
                Assert.That(result.VoltageType, Is.EqualTo(motor.VoltageType));
                Assert.That(result.Frequency, Is.EqualTo(motor.Frequency));
                Assert.That(result.Poles, Is.EqualTo(motor.Poles));
                Assert.That(result.PowerFactor, Is.EqualTo(motor.PowerFactor));
                Assert.That(result.Bearings, Is.EqualTo(motor.Bearings));
            });
        }
    }
}
