using Application.Business;
using Infrastructure.Models;
using SpecControle.Entities;
using SpecControle.UserControls;

namespace SpecControle.UnitTests
{
    public class MeasuredRPMGridTests
    {
        private static DataGridView CreateTestGrid(CustomOrderVentilatorTest test)
        {
            var grid = new DataGridView
            {
                BindingContext = new BindingContext(),
                AutoGenerateColumns = false
            };
            grid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            grid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value" });
            grid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilatorTest), test, BCustomOrderVentilatorTest.ControleDisplayPropertyNames);
            return grid;
        }

        private static DataGridViewCell GetValueCell(DataGridView grid, string propertyName)
        {
            return grid.Rows.Cast<DataGridViewRow>().First(x => x.Cells["Description"].Value?.ToString() == propertyName).Cells["Value"];
        }

        [Test]
        public void TestMeasuringRPMKeepsUnsavedInputAndDoesNotChangeTest()
        {
            var test = new CustomOrderVentilatorTest { Weight = 100, I1High = 1.5m, Date = new DateTime(2026, 10, 21) };
            using var grid = CreateTestGrid(test);

            GetValueCell(grid, nameof(CustomOrderVentilatorTest.Weight)).Value = "250";
            ControleUserControl.SetMeasuredRPM(grid, nameof(CustomOrderVentilatorTest.MeasuredMotorHighRPM), 1450);

            var result = BCustomOrderVentilatorTestUI.CreateObject(grid.Rows.Cast<DataGridViewRow>().ToList());

            Assert.Multiple(() =>
            {
                Assert.That(result.MeasuredMotorHighRPM, Is.EqualTo(1450));
                Assert.That(result.Weight, Is.EqualTo(250));
                Assert.That(result.I1High, Is.EqualTo(1.5m));
                Assert.That(test.Weight, Is.EqualTo(100));
                Assert.That(test.MeasuredMotorHighRPM, Is.Null);
            });
        }

        [Test]
        public void TestMeasuringRPMOnlyChangesSelectedField()
        {
            var test = new CustomOrderVentilatorTest { MeasuredMotorHighRPM = 1400, MeasuredVentilatorHighRPM = 900, Date = new DateTime(2026, 10, 21) };
            using var grid = CreateTestGrid(test);

            ControleUserControl.SetMeasuredRPM(grid, nameof(CustomOrderVentilatorTest.MeasuredVentilatorHighRPM), 950);

            Assert.Multiple(() =>
            {
                Assert.That(GetValueCell(grid, nameof(CustomOrderVentilatorTest.MeasuredVentilatorHighRPM)).Value, Is.EqualTo("950"));
                Assert.That(GetValueCell(grid, nameof(CustomOrderVentilatorTest.MeasuredMotorHighRPM)).Value, Is.EqualTo("1400"));
            });
        }

        [Test]
        public void TestMeasuringRPMWithoutSelectionChangesNothing()
        {
            var test = new CustomOrderVentilatorTest { MeasuredMotorHighRPM = 1400, Date = new DateTime(2026, 10, 21) };
            using var grid = CreateTestGrid(test);
            var valuesBefore = grid.Rows.Cast<DataGridViewRow>().Select(x => x.Cells["Value"].Value).ToList();

            ControleUserControl.SetMeasuredRPM(grid, ControleUserControl.GetMeasuredRPMPropertyName(false, false, false, false), 1450);

            Assert.That(grid.Rows.Cast<DataGridViewRow>().Select(x => x.Cells["Value"].Value), Is.EqualTo(valuesBefore));
        }

        [TestCase(true, false, false, false, nameof(CustomOrderVentilatorTest.MeasuredMotorHighRPM))]
        [TestCase(false, true, false, false, nameof(CustomOrderVentilatorTest.MeasuredMotorLowRPM))]
        [TestCase(false, false, true, false, nameof(CustomOrderVentilatorTest.MeasuredVentilatorHighRPM))]
        [TestCase(false, false, false, true, nameof(CustomOrderVentilatorTest.MeasuredVentilatorLowRPM))]
        [TestCase(false, false, false, false, null)]
        public void TestMeasuredRPMPropertyNameFollowsSelection(bool motorHigh, bool motorLow, bool ventilatorHigh, bool ventilatorLow, string expected)
        {
            Assert.That(ControleUserControl.GetMeasuredRPMPropertyName(motorHigh, motorLow, ventilatorHigh, ventilatorLow), Is.EqualTo(expected));
        }
    }
}
