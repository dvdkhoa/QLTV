using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class B3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuMuon_SinhVien_SinhVien_Id",
                table: "PhieuMuon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_MaSV",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_PhieuMuon_SinhVien_Id",
                table: "PhieuMuon");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "SinhVien_Id",
                table: "PhieuMuon");

            migrationBuilder.AddColumn<string>(
                name: "MaSV",
                table: "PhieuMuon",
                type: "varchar(12)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien",
                column: "MaSV");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuon_MaSV",
                table: "PhieuMuon",
                column: "MaSV",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon",
                column: "MaSV",
                principalTable: "SinhVien",
                principalColumn: "MaSV",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuMuon_SinhVien_MaSV",
                table: "PhieuMuon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien");

            migrationBuilder.DropIndex(
                name: "IX_PhieuMuon_MaSV",
                table: "PhieuMuon");

            migrationBuilder.DropColumn(
                name: "MaSV",
                table: "PhieuMuon");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SinhVien",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SinhVien_Id",
                table: "PhieuMuon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SinhVien",
                table: "SinhVien",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaSV",
                table: "SinhVien",
                column: "MaSV",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuMuon_SinhVien_Id",
                table: "PhieuMuon",
                column: "SinhVien_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuMuon_SinhVien_SinhVien_Id",
                table: "PhieuMuon",
                column: "SinhVien_Id",
                principalTable: "SinhVien",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
