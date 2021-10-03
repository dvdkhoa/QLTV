using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class B4_AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Khoa_MaKhoa",
                table: "Khoa");

            migrationBuilder.AlterColumn<string>(
                name: "TenKhoa",
                table: "Khoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaKhoa",
                table: "Khoa",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "DauSach",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaSach",
                table: "ChiTietMuon",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenBoMon",
                table: "BoMon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaKhoa",
                table: "Khoa",
                column: "MaKhoa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Khoa_MaKhoa",
                table: "Khoa");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "DauSach");

            migrationBuilder.AlterColumn<string>(
                name: "TenKhoa",
                table: "Khoa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaKhoa",
                table: "Khoa",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MaSach",
                table: "ChiTietMuon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TenBoMon",
                table: "BoMon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Khoa_MaKhoa",
                table: "Khoa",
                column: "MaKhoa",
                unique: true,
                filter: "[MaKhoa] IS NOT NULL");
        }
    }
}
