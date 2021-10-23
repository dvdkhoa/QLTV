using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class B5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhuChu",
                table: "DauSach",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaiBan",
                table: "DauSach",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TomTat",
                table: "DauSach",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhuChu",
                table: "DauSach");

            migrationBuilder.DropColumn(
                name: "TaiBan",
                table: "DauSach");

            migrationBuilder.DropColumn(
                name: "TomTat",
                table: "DauSach");
        }
    }
}
