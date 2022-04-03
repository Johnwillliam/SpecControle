using EntityFrameworkModel;
using SpecificationsTesting.Business;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SpecificationsTesting.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace SpecificationsTesting.UserControls
{
    public partial class TestDocumentGenerationUserControl : UserControl
    {
        private CustomOrder CustomOrder { get; set; }
        public int SelectedVentilatorID { get; set; }
        public int SelectedVentilatorTestID { get; set; }
        public TestDocumentGenerationUserControl()
        {
            InitializeComponent();
            this.CustomOrderVentilatorsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorsDataGrid_RowEnter);
            this.CustomOrderVentilatorTestsDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomOrderVentilatorTestsDataGrid_RowEnter);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnPrintSelectedTest.Click += new System.EventHandler(this.btnPrintSelectedTest_Click);
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);

            InitializeGridColumns();
            SelectedVentilatorID = 0;
            SelectedVentilatorTestID = 0;
        }

        private void InitializeGridColumns()
        {

            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            CustomOrderDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderDataGrid.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            CustomOrderDataGrid.RowHeadersVisible = false;
            CustomOrderDataGrid.AutoGenerateColumns = false;
            CustomOrderDataGrid.AllowUserToResizeRows = false;

            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            VentilatorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            VentilatorDataGrid.RowHeadersVisible = false;
            VentilatorDataGrid.AutoGenerateColumns = false;
            VentilatorDataGrid.AllowUserToResizeRows = false;

            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Description", DataPropertyName = "Description", Name = "Description", ReadOnly = true });
            MotorDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "DisplayValue", Name = "Value", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            MotorDataGrid.RowHeadersVisible = false;
            MotorDataGrid.AutoGenerateColumns = false;
            MotorDataGrid.AllowUserToResizeRows = false;

            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "ID", ReadOnly = true });
            CustomOrderVentilatorsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            CustomOrderVentilatorsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorsDataGrid.MultiSelect = false;
            CustomOrderVentilatorsDataGrid.RowPrePaint += new DataGridViewRowPrePaintEventHandler(CustomOrderVentilatorsDataGrid_RowPrePaint);

            CustomOrderVentilatorTestsDataGrid.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Value", DataPropertyName = "Value", ReadOnly = true });
            CustomOrderVentilatorTestsDataGrid.RowHeadersVisible = false;
            CustomOrderVentilatorTestsDataGrid.AutoGenerateColumns = false;
            CustomOrderVentilatorTestsDataGrid.AllowUserToResizeRows = false;
            CustomOrderVentilatorTestsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CustomOrderVentilatorTestsDataGrid.MultiSelect = false;
        }

        private void InitializeGridData(bool initVentilatorsGrid = true, bool initVentilatorTestsGrid = true)
        {
            CustomOrderDataGrid.DataSource = null;
            CustomOrderDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrder), CustomOrder, BCustomOrder.ControleDisplayPropertyNames);
            CustomOrderDataGrid.AutoResizeColumns();

            if (CustomOrder == null)
                CustomOrder = new CustomOrder { ID = -1 };

            if (CustomOrder.CustomOrderVentilators.Count == 0)
                CustomOrder.CustomOrderVentilators.Add(new CustomOrderVentilator());

            var ventilator = SelectedVentilatorID == 0 ? CustomOrder.CustomOrderVentilators.First() : CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID);
            VentilatorDataGrid.DataSource = null;
            VentilatorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderVentilator), ventilator, BCustomOrderVentilator.ControleDisplayPropertyNames);
            VentilatorDataGrid.AutoResizeColumns();

            var selectedTest = SelectedVentilatorTestID == 0 ? ventilator.CustomOrderVentilatorTests.First() : ventilator.CustomOrderVentilatorTests.FirstOrDefault(x => x.ID == SelectedVentilatorTestID);
            if (selectedTest != null && selectedTest.Date == null)
                selectedTest.Date = DateTime.Now.Date;

            if (ventilator.CustomOrderMotor == null)
                ventilator.CustomOrderMotor = new CustomOrderMotor();

            MotorDataGrid.DataSource = null;
            MotorDataGrid.DataSource = ObjectDisplayValue.GetDisplayValues(typeof(CustomOrderMotor), ventilator.CustomOrderMotor, BCustomOrderMotor.ControleDisplayPropertyNames);
            MotorDataGrid.AutoResizeColumns();

            if (initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (CustomOrder != null && initVentilatorsGrid)
            {
                CustomOrderVentilatorsDataGrid.DataSource = null;
                CustomOrderVentilatorsDataGrid.DataSource = CustomOrder.CustomOrderVentilators.ToList();
                CustomOrderVentilatorsDataGrid.AutoResizeColumns();
            }
            if (initVentilatorTestsGrid)
            {
                CustomOrderVentilatorTestsDataGrid.DataSource = null;
                CustomOrderVentilatorTestsDataGrid.DataSource = ventilator.CustomOrderVentilatorTests.Select(x => new { Value = $"Test ID {x.ID}" }).ToList();
                CustomOrderVentilatorTestsDataGrid.AutoResizeColumns();
            }
        }

        private void CustomOrderVentilatorsDataGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void CustomOrderVentilatorsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(CustomOrderVentilatorsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int ventilatorID))
            {
                SelectedVentilatorID = ventilatorID;
                InitializeGridData(false);
            }
        }

        private void CustomOrderVentilatorTestsDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value != null && int.TryParse(CustomOrderVentilatorTestsDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString().Replace("Test ID ", ""), out int testID))
            {
                SelectedVentilatorTestID = testID;
                InitializeGridData(false, false);
            }
        }

        private void ShowCustomOrder()
        {
            if (string.IsNullOrEmpty(txtCustomOrderNumber.Text))
                return;

            var customOrderNumber = int.Parse(txtCustomOrderNumber.Text);
            CustomOrder = BCustomOrder.ByCustomOrderNumber(customOrderNumber);
            if (CustomOrder == null)
            {
                MessageBox.Show($"No order found for number: {customOrderNumber}");
                return;
            }
            if (!BCustomOrderVentilatorTest.ValidateForPrinting(CustomOrder.CustomOrderVentilators.FirstOrDefault(x => x.ID == SelectedVentilatorID)))
                return;

            InitializeGridData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowCustomOrder();
        }

        private void btnPrintSelectedTest_Click(object sender, EventArgs e)
        {
            print();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            print();
        }

        private void print()
        {
            CreateTable("D:\\Projecten\\Fiverr\\joitsys\\MyDocFile-Copy.docx");
        }

        // Insert a table into a word processing document.
        public void CreateTable(string fileName)
        {
            const int yPos = 7500;

            using (WordprocessingDocument doc = WordprocessingDocument.Open(fileName, true))
            {
                MainDocumentPart mainPart = doc.MainDocumentPart;
                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);
                using (FileStream stream = new FileStream("D:\\Projecten\\Fiverr\\joitsys\\RunningTestHeader.png", FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }
                AddImageToBody(doc, mainPart.GetIdOfPart(imagePart));

                SpacingBetweenLines spacing = new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto, Before = "0", After = "0" };
                ParagraphProperties paragraphProperties = new ParagraphProperties();
                Justification justification1 = new Justification() { Val = JustificationValues.Center };
                paragraphProperties.Append(justification1);
                paragraphProperties.Append(spacing);
                Paragraph newParagraph = new Paragraph(paragraphProperties);
                var run = new Run();
                run.Append(new Text("SPECIFICATIE"));
                newParagraph.Append(run);
                doc.MainDocumentPart.Document.Body.Append(newParagraph);

                Table vorderTable = new Table();

                // Create a TableProperties object and specify its border information.
                TableProperties tblPropOrder = new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new BottomBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new LeftBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new RightBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        }
                    )
                );

                // Append the TableProperties object to the empty table.
                vorderTable.AppendChild<TableProperties>(tblPropOrder);

                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Append(new Paragraph(new Run(new Text("Order Gegevens"))));
                tr.Append(tc1);
                vorderTable.Append(tr);
                foreach (DataGridViewRow row in CustomOrderDataGrid.Rows)
                {
                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[0].Value.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[1].Value?.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    vorderTable.Append(tr);
                }

                TablePositionProperties tblPosOrder = new TablePositionProperties() { HorizontalAnchor = HorizontalAnchorValues.Page, VerticalAnchor = VerticalAnchorValues.Page, TablePositionX = 500, TablePositionY = yPos };
                TableOverlap overlapOrder = new TableOverlap() { Val = TableOverlapValues.Overlap };

                tblPropOrder.Append(tblPosOrder, overlapOrder);
                doc.MainDocumentPart.Document.Body.Append(vorderTable);

                Table ventilatorTable = new Table();

                // Create a TableProperties object and specify its border information.
                TableProperties tblProp = new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new BottomBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new LeftBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new RightBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        }
                    )
                );

                // Append the TableProperties object to the empty table.
                ventilatorTable.AppendChild<TableProperties>(tblProp);

                tr = new TableRow();
                tc1 = new TableCell();
                tc1.Append(new Paragraph(new Run(new Text("Ventilator Gegevens"))));
                tr.Append(tc1);
                ventilatorTable.Append(tr);
                foreach (DataGridViewRow row in VentilatorDataGrid.Rows)
                {
                    tr = new TableRow(new TableRowProperties(new TableRowHeight() { Val = Convert.ToUInt32("10") }));
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[0].Value.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[1].Value?.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    ventilatorTable.Append(tr);
                }

                TablePositionProperties tblPos1 = new TablePositionProperties() { HorizontalAnchor = HorizontalAnchorValues.Page, VerticalAnchor = VerticalAnchorValues.Page, TablePositionX = 3500, TablePositionY = yPos };
                TableOverlap overlap1 = new TableOverlap() { Val = TableOverlapValues.Overlap };

                tblProp.Append(tblPos1, overlap1);

                // Append the table to the document.
                doc.MainDocumentPart.Document.Body.Append(ventilatorTable);

                TableProperties tblPropMotor = new TableProperties(
                    new TableBorders(
                        new TopBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new BottomBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new LeftBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new RightBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideHorizontalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        },
                        new InsideVerticalBorder()
                        {
                            Val =
                            new EnumValue<BorderValues>(BorderValues.None),
                            Size = 10
                        }
                    )
                );



                Table motorTable = new Table();
                motorTable.AppendChild<TableProperties>(tblPropMotor);

                tr = new TableRow(new TableRowProperties(new TableRowHeight() { Val = Convert.ToUInt32("20") }));
                tc1 = new TableCell();
                tc1.Append(new Paragraph(new Run(new Text("Motor Gegevens"))));
                tr.Append(tc1);
                motorTable.Append(tr);
                foreach (DataGridViewRow row in MotorDataGrid.Rows)
                {
                    tr = new TableRow();
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[0].Value.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    tc1 = new TableCell();
                    tc1.Append(new Paragraph(new Run(new Text(row.Cells[1].Value?.ToString())), paragraphProperties.CloneNode(true)));
                    tr.Append(tc1);
                    motorTable.Append(tr);
                }

                /// Add position property to right table, set 8700 and 2400 to where you want the table
                TableProperties tblProps2 = motorTable.Descendants<TableProperties>().First();
                TablePositionProperties tblPos2 = new TablePositionProperties() { HorizontalAnchor = HorizontalAnchorValues.Page, VerticalAnchor = VerticalAnchorValues.Page, TablePositionX = 7000, TablePositionY = yPos };
                TableOverlap overlap2 = new TableOverlap() { Val = TableOverlapValues.Overlap };

                tblProps2.Append(tblPos2, overlap2);

                doc.MainDocumentPart.Document.Body.Append(motorTable);

            }
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 6000000L, Cy = 2000000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                       "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 6000000L, Cy = 2000000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to the body. The element should be in 
            // a DocumentFormat.OpenXml.Wordprocessing.Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }

    }
}