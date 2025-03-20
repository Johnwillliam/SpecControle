using EntityFrameworkModelV2.Models;
using Logic.Business;
using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace Logic
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
                   page.Header().PaddingTop(20).MaxHeight(150).AlignCenter().Image(headerImagePath).FitWidth().FitHeight();
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
                .Text($"Datum           {DateTime.Now:dd-MM-yyyy}                                     Handtekening")
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

                    table.Cell().Row(1).Column(1).Element(Block).Text("Serienummer");
                    table.Cell().Row(1).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                    table.Cell().Row(2).Column(1).Element(Block).Text("Motornummer");
                    table.Cell().Row(2).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor?.Type);

                    table.Cell().Row(3).Column(1).Element(Block).Text("Systemair order");
                    table.Cell().Row(3).Column(2).Element(Block).Text(_currentOrder.CustomOrderNumber.ToString());

                    table.Cell().Row(4).Column(1).Element(Block).Text("Bouwjaar");
                    table.Cell().Row(4).Column(2).Element(Block).Text(_currentTest.Date.GetValueOrDefault().Year.ToString());

                    table.Cell().Row(5).Column(1).Element(Block).Text("ATEX Markering");
                    table.Cell().Row(5).Column(2).Element(Block).Text(_currentVentilator.Atex);

                    table.Cell().Row(6).Column(1).Element(Block).Text("Temperatuur bereik");
                    table.Cell().Row(6).Column(2).Element(Block).Text("-20 - +40 °C");

                    table.Cell().Row(7).Column(1).Element(Block).Text("Temperatuurklasse");
                    table.Cell().Row(7).Column(2).Element(Block).Text(_currentVentilator.TemperatureClass?.Description);

                    table.Cell().Row(8).Column(1).Element(Block).Text("Referentie");
                    table.Cell().Row(8).Column(2).Element(Block).Text(_currentOrder.Reference);
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

                    // Row 1
                    table.Cell().Row(1).ColumnSpan(3).Element(Block).Text("VENTILATOR GEGEVENS").Bold();

                    // Row 2
                    table.Cell().Row(2).Column(1).Element(Block).Text("Type").Bold();
                    table.Cell().Row(2).Column(2).Element(Block).Text(_currentVentilator.Name);
                    table.Cell().Row(2).Column(3).Element(Block).Text(string.Empty);

                    // Row 3
                    table.Cell().Row(3).Column(1).Element(Block).Text("Luchthoeveelheid").Bold();
                    table.Cell().Row(3).Column(2).Element(Block).Text(_currentVentilator.HighAirVolume.ToString());
                    table.Cell().Row(3).Column(3).Element(Block).Text("m3/h");

                    // Row 4
                    table.Cell().Row(4).Column(1).Element(Block).Text("Opvoerhoogte totaal").Bold();
                    table.Cell().Row(4).Column(2).Element(Block).Text(_currentVentilator.HighPressureTotal.ToString());
                    table.Cell().Row(4).Column(3).Element(Block).Text("Pa");

                    // Row 5
                    table.Cell().Row(5).Column(1).Element(Block).Text("Opvoerhoogte statisch").Bold();
                    table.Cell().Row(5).Column(2).Element(Block).Text(_currentVentilator.HighPressureStatic.ToString());
                    table.Cell().Row(5).Column(3).Element(Block).Text("Pa");

                    // Row 6
                    table.Cell().Row(6).Column(1).Element(Block).Text("Opvoerhoogte dynamisch").Bold();
                    table.Cell().Row(6).Column(2).Element(Block).Text(_currentVentilator.HighPressureDynamic.ToString());
                    table.Cell().Row(6).Column(3).Element(Block).Text("Pa");

                    // Row 7
                    table.Cell().Row(7).Column(1).Element(Block).Text("Toerental").Bold();
                    table.Cell().Row(7).Column(2).Element(Block).Text(_currentVentilator.HighRPM.ToString());
                    table.Cell().Row(7).Column(3).Element(Block).Text("rpm");

                    // Row 8
                    table.Cell().Row(8).Column(1).Element(Block).Text("Rendement").Bold();
                    table.Cell().Row(8).Column(2).Element(Block).Text(_currentVentilator.Efficiency.ToString());
                    table.Cell().Row(8).Column(3).Element(Block).Text("%");

                    // Row 9
                    table.Cell().Row(9).Column(1).Element(Block).Text("Asvermogen").Bold();
                    table.Cell().Row(9).Column(2).Element(Block).Text(_currentVentilator.HighShaftPower.ToString());
                    table.Cell().Row(9).Column(3).Element(Block).Text("kW");

                    // Row 10
                    table.Cell().Row(10).Column(1).Element(Block).Text("Geluidsvermogen").Bold();
                    table.Cell().Row(10).Column(2).Element(Block).Text(_currentVentilator.SoundLevel.ToString());
                    table.Cell().Row(10).Column(3).Element(Block).Text("dB");

                    // Row 11
                    table.Cell().Row(11).Column(1).Element(Block).Text("Schoephoek").Bold();
                    table.Cell().Row(11).Column(2).Element(Block).Text(_currentVentilator.BladeAngle.ToString());
                    table.Cell().Row(11).Column(3).Element(Block).Text("°");
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

                    // Row 1
                    table.Cell().Row(1).ColumnSpan(3).Element(Block).Text("MOTOR GEGEVENS").Bold();

                    // Row 2
                    table.Cell().Row(2).Column(1).Element(Block).Text("Fabrikaat").Bold();
                    table.Cell().Row(2).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Name);
                    table.Cell().Row(2).Column(3).Element(Block).Text(string.Empty);

                    // Row 3
                    table.Cell().Row(3).Column(1).Element(Block).Text("Type").Bold();
                    table.Cell().Row(3).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Type);
                    table.Cell().Row(3).Column(3).Element(Block).Text(string.Empty);

                    // Row 4
                    table.Cell().Row(4).Column(1).Element(Block).Text("Uitvoering").Bold();
                    table.Cell().Row(4).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Version);
                    table.Cell().Row(4).Column(3).Element(Block).Text(string.Empty);

                    // Row 5
                    table.Cell().Row(5).Column(1).Element(Block).Text("Bouwgrootte").Bold();
                    table.Cell().Row(5).Column(2).Element(Block).Text(_currentTest.BuildSize.ToString());
                    table.Cell().Row(5).Column(3).Element(Block).Text(string.Empty);

                    // Row 6
                    table.Cell().Row(6).Column(1).Element(Block).Text("Bouwvorm").Bold();
                    table.Cell().Row(6).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.BuildingType);
                    table.Cell().Row(6).Column(3).Element(Block).Text(string.Empty);

                    // Row 7
                    table.Cell().Row(7).Column(1).Element(Block).Text("Beschermklasse").Bold();
                    table.Cell().Row(7).Column(2).Element(Block).Text("55");
                    table.Cell().Row(7).Column(3).Element(Block).Text(string.Empty);

                    // Row 8
                    table.Cell().Row(8).Column(1).Element(Block).Text("Isolatieklasse").Bold();
                    table.Cell().Row(8).Column(2).Element(Block).Text("F");
                    table.Cell().Row(8).Column(3).Element(Block).Text(string.Empty);

                    // Row 9
                    table.Cell().Row(9).Column(1).Element(Block).Text("Nominaal vermogen").Bold();
                    table.Cell().Row(9).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.HighPower.ToString());
                    table.Cell().Row(9).Column(3).Element(Block).Text("kW");

                    // Row 10
                    table.Cell().Row(10).Column(1).Element(Block).Text("Toerental").Bold();
                    table.Cell().Row(10).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.HighRPM.ToString());
                    table.Cell().Row(10).Column(3).Element(Block).Text("rpm");

                    // Row 11
                    table.Cell().Row(11).Column(1).Element(Block).Text("Nominaal stroom").Bold();
                    table.Cell().Row(11).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.HighAmperage.ToString());
                    table.Cell().Row(11).Column(3).Element(Block).Text("A");

                    // Row 12
                    table.Cell().Row(12).Column(1).Element(Block).Text("Arbeidsfactor").Bold();
                    table.Cell().Row(12).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.PowerFactor.ToString());
                    table.Cell().Row(12).Column(3).Element(Block).Text(string.Empty);

                    // Row 13
                    table.Cell().Row(13).Column(1).Element(Block).Text("Aanloopstroom").Bold();
                    table.Cell().Row(13).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.HighStartupAmperage.ToString());
                    table.Cell().Row(13).Column(3).Element(Block).Text("A");

                    // Row 14
                    table.Cell().Row(14).Column(1).Element(Block).Text("Aansluitspanning").Bold();
                    table.Cell().Row(14).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.VoltageType);
                    table.Cell().Row(14).Column(3).Element(Block).Text("V");

                    // Row 15
                    table.Cell().Row(15).Column(1).Element(Block).Text("Frequentie").Bold();
                    table.Cell().Row(15).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Frequency.ToString());
                    table.Cell().Row(15).Column(3).Element(Block).Text("Hz");
                });
        }
    }
}