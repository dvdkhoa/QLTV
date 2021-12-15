using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class fix_sv_pm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon");

            migrationBuilder.AlterColumn<string>(
                name: "TenTG",
                table: "TacGia",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TenNXB",
                table: "NXB",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon",
                column: "MaSV",
                principalTable: "SinhVien",
                principalColumn: "MaSV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon");

            migrationBuilder.AlterColumn<string>(
                name: "TenTG",
                table: "TacGia",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TenNXB",
                table: "NXB",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon",
                column: "MaSV",
                principalTable: "SinhVien",
                principalColumn: "MaSV",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
