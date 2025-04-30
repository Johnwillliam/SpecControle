using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application;
using Application.Business;
using Infrastructure.Models;

namespace Application.PdfGenerators
{
    public class AtexPdfDocumentGenerator : IDocument
    {
        private readonly List<CustomOrderVentilatorTest> _tests;
        private readonly ILogger logger;
        private CustomOrderVentilatorTest _currentTest;
        private CustomOrderVentilator _currentVentilator;
        private CustomOrder _currentOrder;

        public DocumentMetadata Metadata { get; set; }

        public AtexPdfDocumentGenerator(List<CustomOrderVentilatorTest> tests, ILogger logger)
        {
            _tests = tests;
            this.logger = logger;
        }

        public byte[] Generate() => this.GeneratePdf();

        public void Compose(IDocumentContainer container)
        {
            container
               .Page(page =>
               {
                   var headerImagePath = Environment.CurrentDirectory + "\\Resources\\AtexDocumentHeader.jpg";
                   page.Header().PaddingTop(20).MaxHeight(150).AlignCenter().Image(headerImagePath).FitHeight();
                   page.DefaultTextStyle(x => x.FontSize(8));
                   page.Content().Element(ComposeContent);
                   page.Size(PageSizes.A4);

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
                column.Item().Element(AddSpecificationText);

                foreach (var test in _tests)
                {
                    _currentTest = test;
                    _currentVentilator = BCustomOrderVentilator.GetById(_currentTest.CustomOrderVentilatorID);
                    _currentOrder = BCustomOrder.ById(_currentVentilator.CustomOrderID);
                    column.Item().Element(CreateOrderTable);
                    column.Item().Element(CreateVentilatorTable);
                    column.Item().Element(CreateMotorTable);
                    column.Item().Element(AddDateAndSignature);
                }
            });
        }

        private static void AddDateAndSignature(IContainer container)
        {
            container
                .Text($"Datum           {DateTime.Now:dd-MM-yyyy}")
                .FontSize(10)
                .Bold();
        }

        private static void AddSpecificationText(IContainer container)
        {
            container
                .AlignCenter()
                .Text("SPECIFICATIE")
                .Bold()
                .FontSize(15);
        }

        private void CreateOrderTable(IContainer container)
        {
            if (_currentVentilator == null)
            {
                ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                return;
            }

            container
                .PaddingTop(10)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(50);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Serienummer");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentTest.SerialNumber.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Motornummer");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor?.Type);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Systemair order");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Bouwjaar");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentTest.Date.GetValueOrDefault().Year.ToString());

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("ATEX Markering");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.Atex);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Temperatuur bereik");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text("-20 - +40 °C");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Temperatuurklasse");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentVentilator.TemperatureClass?.Description);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Referentie");
                    table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentOrder.Reference);
                });
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

        private void CreateVentilatorTable(IContainer container)
        {
            if (_currentVentilator == null)
            {
                ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                return;
            }

            container
                .PaddingTop(10)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(25);
                        columns.RelativeColumn(25);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("VENTILATOR GEGEVENS").Bold();

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Type").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.Name);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Luchthoeveelheid").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighAirVolume} / {_currentVentilator.LowAirVolume}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("m3/h");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Opvoerhoogte totaal").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.HighPressureTotal.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Opvoerhoogte statisch").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.HighPressureStatic.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Opvoerhoogte dynamisch").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.HighPressureDynamic.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Toerental").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighRPM} / {_currentVentilator.LowRPM}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Rendement").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.Efficiency.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("%");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Asvermogen").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighShaftPower} / {_currentVentilator.LowShaftPower}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("kW");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Geluidsvermogen").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.SoundLevel.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("dB");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Schoephoek").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.BladeAngle.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("°");
                });
        }

        private void CreateMotorTable(IContainer container)
        {
            if (_currentVentilator == null)
            {
                ExceptionHandler.HandleException(logger, new Exception("No ventilator found in function CreateOrderTable."));
                return;
            }

            container
                .PaddingTop(10)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(50);
                        columns.RelativeColumn(25);
                        columns.RelativeColumn(25);
                    });

                    uint rowIndex = 1;

                    table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("MOTOR GEGEVENS").Bold();

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Fabrikaat").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Name);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Type").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Type);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Uitvoering").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Version);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Bouwgrootte").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentTest.BuildSize.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Bouwvorm").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.BuildingType);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Beschermklasse").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text("55");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Isolatieklasse").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text("F");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Nominaal vermogen").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighPower} / {_currentVentilator.CustomOrderMotor.LowPower}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("kW");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Toerental").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighRPM} / {_currentVentilator.CustomOrderMotor.LowRPM}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Nominaal stroom").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighAmperage} / {_currentVentilator.CustomOrderMotor.LowAmperage}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Arbeidsfactor").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.PowerFactor.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Aanloopstroom").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighStartupAmperage} / {_currentVentilator.CustomOrderMotor.LowStartupAmperage}");
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Aansluitspanning").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.VoltageType);
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("V");

                    table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Frequentie").Bold();
                    table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Frequency.ToString());
                    table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Hz");
                });
        }
    }
}
