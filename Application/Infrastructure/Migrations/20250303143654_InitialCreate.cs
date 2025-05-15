using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATEXTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATEXTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CatTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrderMotors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IEC = table.Column<int>(type: "int", nullable: true),
                    IP = table.Column<int>(type: "int", nullable: true),
                    PTC = table.Column<bool>(type: "bit", nullable: true),
                    HT = table.Column<bool>(type: "bit", nullable: true),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    HighRPM = table.Column<int>(type: "int", nullable: true),
                    LowRPM = table.Column<int>(type: "int", nullable: true),
                    HighAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    HighStartupAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowStartupAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    VoltageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    PowerFactor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Bearings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderMotors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomOrderNumber = table.Column<int>(type: "int", nullable: false),
                    Debtor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroupTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SoundLevelTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundLevelTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureClasses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureClasses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TemplateMotors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IEC = table.Column<int>(type: "int", nullable: true),
                    IP = table.Column<int>(type: "int", nullable: true),
                    PTC = table.Column<bool>(type: "bit", nullable: true),
                    HT = table.Column<bool>(type: "bit", nullable: true),
                    BuildingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    HighRPM = table.Column<int>(type: "int", nullable: true),
                    LowRPM = table.Column<int>(type: "int", nullable: true),
                    HighAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    HighStartupAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowStartupAmperage = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    VoltageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    Poles = table.Column<int>(type: "int", nullable: true),
                    PowerFactor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Bearings = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateMotors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VentilatorTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentilatorTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomOrderVentilators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomOrderID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomOrderMotorID = table.Column<int>(type: "int", nullable: false),
                    VentilatorTypeID = table.Column<int>(type: "int", nullable: true),
                    HighAirVolume = table.Column<int>(type: "int", nullable: true),
                    LowAirVolume = table.Column<int>(type: "int", nullable: true),
                    HighPressureTotal = table.Column<int>(type: "int", nullable: true),
                    LowPressureTotal = table.Column<int>(type: "int", nullable: true),
                    HighPressureStatic = table.Column<int>(type: "int", nullable: true),
                    LowPressureStatic = table.Column<int>(type: "int", nullable: true),
                    HighPressureDynamic = table.Column<int>(type: "int", nullable: true),
                    LowPressureDynamic = table.Column<int>(type: "int", nullable: true),
                    HighRPM = table.Column<int>(type: "int", nullable: true),
                    LowRPM = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    HighShaftPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    LowShaftPower = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SoundLevel = table.Column<int>(type: "int", nullable: true),
                    SoundLevelTypeID = table.Column<int>(type: "int", nullable: true),
                    BladeAngle = table.Column<int>(type: "int", nullable: true),
                    Atex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupTypeID = table.Column<int>(type: "int", nullable: true),
                    TemperatureClassID = table.Column<int>(type: "int", nullable: true),
                    CatTypeID = table.Column<int>(type: "int", nullable: true),
                    CatOutID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderVentilators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_CatTypes_CatTypeID",
                        column: x => x.CatTypeID,
                        principalTable: "CatTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_CustomOrderMotors_CustomOrderMotorID",
                        column: x => x.CustomOrderMotorID,
                        principalTable: "CustomOrderMotors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_CustomOrders_CustomOrderID",
                        column: x => x.CustomOrderID,
                        principalTable: "CustomOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_GroupTypes_GroupTypeID",
                        column: x => x.GroupTypeID,
                        principalTable: "GroupTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_SoundLevelTypes_SoundLevelTypeID",
                        column: x => x.SoundLevelTypeID,
                        principalTable: "SoundLevelTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_TemperatureClasses_TemperatureClassID",
                        column: x => x.TemperatureClassID,
                        principalTable: "TemperatureClasses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilators_VentilatorTypes_VentilatorTypeID",
                        column: x => x.VentilatorTypeID,
                        principalTable: "VentilatorTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TemplateVentilators",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VentilatorTypeID = table.Column<int>(type: "int", nullable: true),
                    AirVolume = table.Column<int>(type: "int", nullable: true),
                    PressureTotal = table.Column<int>(type: "int", nullable: true),
                    PressureStatic = table.Column<int>(type: "int", nullable: true),
                    PressureDynamic = table.Column<int>(type: "int", nullable: true),
                    RPM = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    ShaftPower = table.Column<int>(type: "int", nullable: true),
                    SoundLevel = table.Column<int>(type: "int", nullable: true),
                    SoundLevelTypeID = table.Column<int>(type: "int", nullable: true),
                    BladeAngle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateVentilators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TemplateVentilators_SoundLevelTypes_SoundLevelTypeID",
                        column: x => x.SoundLevelTypeID,
                        principalTable: "SoundLevelTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TemplateVentilators_VentilatorTypes_VentilatorTypeID",
                        column: x => x.VentilatorTypeID,
                        principalTable: "VentilatorTypes",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CustomOrderVentilatorTests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomOrderVentilatorID = table.Column<int>(type: "int", nullable: false),
                    MeasuredVentilatorHighRPM = table.Column<int>(type: "int", nullable: true),
                    MeasuredVentilatorLowRPM = table.Column<int>(type: "int", nullable: true),
                    MeasuredMotorHighRPM = table.Column<int>(type: "int", nullable: true),
                    MeasuredMotorLowRPM = table.Column<int>(type: "int", nullable: true),
                    MeasuredBladeAngle = table.Column<int>(type: "int", nullable: true),
                    Cover = table.Column<int>(type: "int", nullable: true),
                    MotorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    I1High = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    I1Low = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    I2High = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    I2Low = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    I3High = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    I3Low = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    BuildSize = table.Column<int>(type: "int", nullable: true),
                    Locked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOrderVentilatorTests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilatorTests_CustomOrderVentilators_CustomOrderVentilatorID",
                        column: x => x.CustomOrderVentilatorID,
                        principalTable: "CustomOrderVentilators",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomOrderVentilatorTests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_CatTypeID",
                table: "CustomOrderVentilators",
                column: "CatTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_CustomOrderID",
                table: "CustomOrderVentilators",
                column: "CustomOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_CustomOrderMotorID",
                table: "CustomOrderVentilators",
                column: "CustomOrderMotorID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_GroupTypeID",
                table: "CustomOrderVentilators",
                column: "GroupTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_SoundLevelTypeID",
                table: "CustomOrderVentilators",
                column: "SoundLevelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_TemperatureClassID",
                table: "CustomOrderVentilators",
                column: "TemperatureClassID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_VentilatorTypeID",
                table: "CustomOrderVentilators",
                column: "VentilatorTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilatorTests_CustomOrderVentilatorID",
                table: "CustomOrderVentilatorTests",
                column: "CustomOrderVentilatorID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilatorTests_UserID",
                table: "CustomOrderVentilatorTests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateVentilators_SoundLevelTypeID",
                table: "TemplateVentilators",
                column: "SoundLevelTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateVentilators_VentilatorTypeID",
                table: "TemplateVentilators",
                column: "VentilatorTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATEXTypes");

            migrationBuilder.DropTable(
                name: "CustomOrderVentilatorTests");

            migrationBuilder.DropTable(
                name: "TemplateMotors");

            migrationBuilder.DropTable(
                name: "TemplateVentilators");

            migrationBuilder.DropTable(
                name: "CustomOrderVentilators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CatTypes");

            migrationBuilder.DropTable(
                name: "CustomOrderMotors");

            migrationBuilder.DropTable(
                name: "CustomOrders");

            migrationBuilder.DropTable(
                name: "GroupTypes");

            migrationBuilder.DropTable(
                name: "SoundLevelTypes");

            migrationBuilder.DropTable(
                name: "TemperatureClasses");

            migrationBuilder.DropTable(
                name: "VentilatorTypes");
        }
    }
}