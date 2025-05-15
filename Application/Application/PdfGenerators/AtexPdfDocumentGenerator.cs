using Microsoft.Extensions.Logging;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Application.Business;
using Infrastructure.Models;

namespace Application.PdfGenerators;

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
               page.Size(PageSizes.A4);
               var headerImagePath = Environment.CurrentDirectory + "\\Resources\\AtexDocumentHeader.jpg";
               page.Header().PaddingTop(20).MaxHeight(150).AlignCenter().Image(headerImagePath).FitHeight();
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
        container.PaddingVertical(20).PaddingHorizontal(30).Column(column =>
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
            .Text($"Date           {DateTime.Now:dd-MM-yyyy}")
            .FontSize(10)
            .Bold();
    }

    private static void AddSpecificationText(IContainer container)
    {
        container
            .AlignCenter()
            .Text("SPECIFICATION")
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

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Serial number");
                table.Cell().Row(rowIndex++).Column(2).Element(Block).Text(_currentTest.SerialNumber.ToString());

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

                table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("FAN DETAILS").Bold();

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Type").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.Name);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Air volume").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighAirVolume} / {_currentVentilator.LowAirVolume}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("m3/h");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Total pressure").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureTotal} / {_currentVentilator.LowPressureTotal}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Static pressure").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureStatic} / {_currentVentilator.LowPressureStatic}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Dynamic pressure").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighPressureDynamic} / {_currentVentilator.LowPressureDynamic}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Pa");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Speed").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighRPM} / {_currentVentilator.LowRPM}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Efficiency").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.Efficiency.ToString());
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("%");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Shaft power").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.HighShaftPower} / {_currentVentilator.LowShaftPower}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("kW");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Sound power level").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.SoundLevel.ToString());
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("dB");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Blade angle").Bold();
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

                table.Cell().Row(rowIndex++).ColumnSpan(3).Element(Block).Text("MOTOR DETAILS").Bold();

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Brand").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Name);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Type").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Type);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Version").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Version);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Frame size").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentTest.BuildSize.ToString());
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Building type").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.BuildingType);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Protection class").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text("55");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Insulation class").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text("F");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Nominal power").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighPower} / {_currentVentilator.CustomOrderMotor.LowPower}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("kW");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Speed").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighRPM} / {_currentVentilator.CustomOrderMotor.LowRPM}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("rpm");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Nominal current").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighAmperage} / {_currentVentilator.CustomOrderMotor.LowAmperage}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Power factor").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.PowerFactor.ToString());
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text(string.Empty);

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Startup current").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text($"{_currentVentilator.CustomOrderMotor.HighStartupAmperage} / {_currentVentilator.CustomOrderMotor.LowStartupAmperage}");
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("A");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Connection voltage").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.VoltageType);
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("V");

                table.Cell().Row(rowIndex).Column(1).Element(Block).Text("Frequency").Bold();
                table.Cell().Row(rowIndex).Column(2).Element(Block).Text(_currentVentilator.CustomOrderMotor.Frequency.ToString());
                table.Cell().Row(rowIndex++).Column(3).Element(Block).Text("Hz");
            });
    }
}