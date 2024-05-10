using EntityFrameworkModelV2.Models;
using Logic.Business;
using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Logic.PdfGenerators
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
                   page.DefaultTextStyle(x => x.FontSize(8));
                   page.Margin(50);
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
            container.PaddingVertical(0).Column(column =>
            {
                foreach (var test in _tests)
                {
                    if (_tests.IndexOf(test) > 0)
                    {
                        column.Item().PageBreak();
                    }

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
            container
                .Text($"Datum assemblage             {_currentTest.Date:yyyy-dd-MM}")
                .FontSize(10)
                .Bold();
        }

        private void AddAssemblyBy(IContainer container)
        {
            container
                .Text($"Uitgevoerd door                  {_currentTest.User?.Name}")
                .FontSize(10)
                .Bold();
        }

        private static void AddRunningTestText(IContainer container)
        {
            container
                .AlignCenter()
                .Text("RUNNING TEST")
                .Bold()
                .FontSize(15);
        }

        private void AddVentilatorTypeText(IContainer container)
        {
            container
                .AlignCenter()
                .Text(_currentVentilator.VentilatorType?.Description)
                .Bold()
                .FontSize(15);
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

                container
                    .PaddingTop(10)
                    .PaddingBottom(10)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                        });

                        table.Cell().Row(1).Column(1).Element(Block).Text("Systemair order");
                        table.Cell().Row(1).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                        table.Cell().Row(2).Column(1).Element(Block).Text("Referentie");
                        table.Cell().Row(2).Column(2).Element(Block).Text(_currentOrder.Reference);

                        table.Cell().Row(3).Column(1).Element(Block).Text("Serienummer");
                        table.Cell().Row(3).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                        table.Cell().Row(4).Column(1).Element(Block).Text("Motornummer");
                        table.Cell().Row(4).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Type);
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

                container
                    .PaddingTop(10)
                    .PaddingBottom(10)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                        });

                        table.Cell().Row(1).ColumnSpan(3).Element(Block).Text("VENTILATOR GEGEVENS").Bold();

                        table.Cell().Row(2).Column(1).Element(Block).Text("Type");
                        table.Cell().Row(2).Column(2).Element(Block).Text(_currentVentilator.Name);
                        table.Cell().Row(2).Column(3).Element(Block).Text(string.Empty);

                        table.Cell().Row(3).Column(1).Element(Block).Text("Toerental");
                        table.Cell().Row(3).Column(2).Element(Block).Text(_currentVentilator.HighRPM.ToString());
                        table.Cell().Row(3).Column(3).Element(Block).Text("rpm");

                        table.Cell().Row(4).Column(1).Element(Block).Text("Schoephoek");
                        table.Cell().Row(4).Column(2).Element(Block).Text(_currentVentilator.BladeAngle.ToString());
                        table.Cell().Row(4).Column(3).Element(Block).Text("°");
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

                container
                    .PaddingTop(10)
                    .PaddingBottom(10)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                        });

                        table.Cell().Row(1).ColumnSpan(2).Element(Block).Text("MOTOR GEGEVENS").Bold();

                        table.Cell().Row(2).Column(1).Element(Block).Text("Serienummer");
                        table.Cell().Row(2).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                        table.Cell().Row(3).Column(1).Element(Block).Text("Motornummer");
                        table.Cell().Row(3).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor?.Type);

                        table.Cell().Row(4).Column(1).Element(Block).Text("Systemair order");
                        table.Cell().Row(4).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                        table.Cell().Row(5).Column(1).Element(Block).Text("Bouwjaar");
                        table.Cell().Row(5).Column(2).Element(Block).Text(_currentTest.Date.GetValueOrDefault().Year.ToString());

                        table.Cell().Row(6).Column(1).Element(Block).Text("ATEX Markering");
                        table.Cell().Row(6).Column(2).Element(Block).Text(_currentVentilator.Atex);

                        table.Cell().Row(7).Column(1).Element(Block).Text("Temperatuur bereik");
                        table.Cell().Row(7).Column(2).Element(Block).Text("-20 - +40 °C");

                        table.Cell().Row(8).Column(1).Element(Block).Text("Temperatuurklasse");
                        table.Cell().Row(8).Column(2).Element(Block).Text(_currentVentilator.TemperatureClass?.Description);

                        table.Cell().Row(9).Column(1).Element(Block).Text("Referentie");
                        table.Cell().Row(9).Column(2).Element(Block).Text(_currentOrder.Reference);
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

                container
                    .PaddingTop(10)
                    .PaddingBottom(10)
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                            columns.RelativeColumn(50);
                        });

                        table.Cell().Row(1).ColumnSpan(3).Element(Block).Text("MEETGEGEVENS").Bold();

                        table.Cell().Row(2).Column(1).Element(Block).Text("Stroom I1");
                        table.Cell().Row(2).Column(2).Element(Block).Text(_currentTest.I1High.ToString());
                        table.Cell().Row(2).Column(3).Element(Block).Text("A");

                        table.Cell().Row(3).Column(1).Element(Block).Text("Stroom I2");
                        table.Cell().Row(3).Column(2).Element(Block).Text(_currentTest.I2High.ToString());
                        table.Cell().Row(3).Column(3).Element(Block).Text("A");

                        table.Cell().Row(4).Column(1).Element(Block).Text("Stroom I3");
                        table.Cell().Row(4).Column(2).Element(Block).Text(_currentTest.I3High.ToString());
                        table.Cell().Row(4).Column(3).Element(Block).Text("A");

                        table.Cell().Row(5).Column(1).Element(Block).Text("Toerental motor");
                        table.Cell().Row(5).Column(2).Element(Block).Text(_currentTest.MeasuredMotorHighRPM.ToString());
                        table.Cell().Row(5).Column(3).Element(Block).Text("rpm");

                        table.Cell().Row(6).Column(1).Element(Block).Text("Toerental ventilator");
                        table.Cell().Row(6).Column(2).Element(Block).Text(_currentTest.MeasuredVentilatorHighRPM.ToString());
                        table.Cell().Row(6).Column(3).Element(Block).Text("rpm");

                        table.Cell().Row(7).Column(1).Element(Block).Text("Schoephoek");
                        table.Cell().Row(7).Column(2).Element(Block).Text(_currentTest.MeasuredBladeAngle.ToString());
                        table.Cell().Row(7).Column(3).Element(Block).Text("°");
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