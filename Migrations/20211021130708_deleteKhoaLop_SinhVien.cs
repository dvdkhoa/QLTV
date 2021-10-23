using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class deleteKhoaLop_SinhVien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Khoa_Khoa_Id",
                table: "SinhVien");

            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Nganh_Nganh_Id",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_Khoa_Id",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_Nganh_Id",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "Khoa_Id",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "Nganh_Id",
                table: "SinhVien");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Khoa_Id",
                table: "SinhVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nganh_Id",
                table: "SinhVien",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Khoa_Id",
                table: "SinhVien",
                column: "Khoa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_Nganh_Id",
                table: "SinhVien",
                column: "Nganh_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Khoa_Khoa_Id",
                table: "SinhVien",
                column: "Khoa_Id",
                principalTable: "Khoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Nganh_Nganh_Id",
                table: "SinhVien",
                column: "Nganh_Id",
                principalTable: "Nganh",
                principalColumn: "Id");
        }
    }
}
