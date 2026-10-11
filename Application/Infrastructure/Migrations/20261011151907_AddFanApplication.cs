using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFanApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FanApplicationID",
                table: "CustomOrderVentilators",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FanApplications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanApplications", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomOrderVentilators_FanApplicationID",
                table: "CustomOrderVentilators",
                column: "FanApplicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomOrderVentilators_FanApplications_FanApplicationID",
                table: "CustomOrderVentilators",
                column: "FanApplicationID",
                principalTable: "FanApplications",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomOrderVentilators_FanApplications_FanApplicationID",
                table: "CustomOrderVentilators");

            migrationBuilder.DropTable(
                name: "FanApplications");

            migrationBuilder.DropIndex(
                name: "IX_CustomOrderVentilators_FanApplicationID",
                table: "CustomOrderVentilators");

            migrationBuilder.DropColumn(
                name: "FanApplicationID",
                table: "CustomOrderVentilators");
        }
    }
}
