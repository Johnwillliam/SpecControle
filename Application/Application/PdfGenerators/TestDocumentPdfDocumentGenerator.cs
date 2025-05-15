using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application.Business;
using Infrastructure.Models;

namespace Application.PdfGenerators
{
    public class TestDocumentPdfDocumentGenerator : IDocument
    {
        private readonly List<CustomOrderVentilatorTest> _tests;
        private readonly ILogger logger;
        private CustomOrderVentilatorTest _currentTest;
        private CustomOrderVentilator _currentVentilator;
        private CustomOrder _currentOrder;

        public DocumentMetadata Metadata { get; set; }

        public TestDocumentPdfDocumentGenerator(List<CustomOrderVentilatorTest> tests, ILogger logger)
        {
            _tests = tests;
            this.logger = logger;
        }

        public void Generate(Stream stream) => this.GeneratePdf(stream);

        public void Compose(IDocumentContainer container)
        {
            container
               .Page(page =>
               {
                   page.Size(PageSizes.A4);
                   page.DefaultTextStyle(x => x.FontSize(8));
                   page.Content().Element(ComposeContent);

                   page.Footer().AlignCenter().Text(x =>
                   {
                       x.CurrentPageNumber();
                       x.Span(" / ");
                       x.TotalPages();
                   });
               });
        }

        private void ComposeContent(IContainer container)
        {
            container.PaddingVertical(30).PaddingHorizontal(30).Column(column =>
            {
                foreach (var test in _tests)
                {
                    if (_tests.IndexOf(test) > 0)
                        column.Item().PageBreak();

                    _currentTest = test;
                    _currentVentilator = BCustomOrderVentilator.GetById(_currentTest.CustomOrderVentilatorID);
                    _currentOrder = BCustomOrder.ById(_currentVentilator.CustomOrderID);
                    column.Item().Element(AddRunningTestText);
                    column.Item().Element(AddVentilatorTypeText);
                    column.Item().Element(CreateOrderTable);
                    column.Item().Element(CreateVentilatorTable);
                    column.Item().Element(CreateMotorTable);
                    column.Item().Element(CreateTestTable);
                    column.Item().Element(AddAssemblyDate);
                    column.Item().Element(AddAssemblyBy);
                }
            });
        }

        private void AddAssemblyDate(IContainer container)
        {
            container.Text($"Assembly date             {_currentTest.Date:yyyy-dd-MM}").FontSize(10).Bold();
        }

        private void AddAssemblyBy(IContainer container)
        {
            container.Text($"Performed by                  {_currentTest.User?.Name}").FontSize(10).Bold();
        }

        private static void AddRunningTestText(IContainer container)
        {
            container.AlignCenter().Text("RUNNING TEST").Bold().FontSize(15);
        }

        private void AddVentilatorTypeText(IContainer container)
        {
            container.AlignCenter().Text(_currentVentilator.VentilatorType?.Description).Bold().FontSize(15);
        }

        private void CreateOrderTable(IContainer container)
        {
            try
            {
                if (_currentVentilator == null)
                {
                    ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                    return;
                }

                container.PaddingTop(10).PaddingBottom(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Systemair order");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Reference");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.Reference);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Serial number");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentTest.SerialNumber.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Motor number");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Type);
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(logger, ex);
            }
        }

        private void CreateVentilatorTable(IContainer container)
        {
            try
            {
                if (_currentVentilator == null)
                {
                    ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                    return;
                }

                container.PaddingTop(10).PaddingBottom(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("FAN DETAILS").Bold();

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Type");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.Name);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Speed");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighRPM} / {_currentVentilator.LowRPM}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Total pressure");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureTotal} / {_currentVentilator.LowPressureTotal}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Static pressure");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureStatic} / {_currentVentilator.LowPressureStatic}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Dynamic pressure");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureDynamic} / {_currentVentilator.LowPressureDynamic}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Blade angle");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.BladeAngle.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("°");
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(logger, ex);
            }
        }

        private void CreateMotorTable(IContainer container)
        {
            try
            {
                if (_currentVentilator == null)
                {
                    ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                    return;
                }

                container.PaddingTop(10).PaddingBottom(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex++).ColumnSpan(2).Element(Block).Text("MOTOR DETAILS").Bold();

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Motor number");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor?.Type);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Systemair order");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Year of construction");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentTest.Date.GetValueOrDefault().Year.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("ATEX Marking");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.Atex);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Temperature range");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text("-20 - +40 °C");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Temperature class");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.TemperatureClass?.Description);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Reference");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.Reference);
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(logger, ex);
            }
        }

        private void CreateTestTable(IContainer container)
        {
            try
            {
                if (_currentVentilator == null)
                {
                    ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                    return;
                }

                container.PaddingTop(10).PaddingBottom(10).Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("MEASURED DATA").Bold();

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Current I1");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentTest.I1High} / {_currentTest.I1Low}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Current I2");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentTest.I2High} / {_currentTest.I2Low}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Current I3");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentTest.I3High} / {_currentTest.I3Low}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Motor speed");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentTest.MeasuredMotorHighRPM} / {_currentTest.MeasuredMotorLowRPM}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Fan speed");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentTest.MeasuredVentilatorHighRPM} / {_currentTest.MeasuredVentilatorLowRPM}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Blade angle");
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentTest.MeasuredBladeAngle.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("°");
                });
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(logger, ex);
            }
        }

        private static IContainer Block(IContainer container)
        {
            return container
                .Border(1)
                .ShowOnce()
                .MinWidth(50)
                .MinHeight(15)
                .AlignCenter()
                .AlignMiddle();
        }
    }
}