using Microsoft.EntityFrameworkCore.Migrations;

namespace QLTV.AppMVC.Migrations
{
    public partial class B2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietMuon_Sach_Sach_Id",
                table: "ChiTietMuon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sach",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietMuon_Sach_Id",
                table: "ChiTietMuon");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "Sach_Id",
                table: "ChiTietMuon");

            migrationBuilder.AddColumn<string>(
                name: "MaSach",
                table: "Sach",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaSach",
                table: "ChiTietMuon",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sach",
                table: "Sach",
                column: "MaSach");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_MaSach",
                table: "ChiTietMuon",
                column: "MaSach");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietMuon_Sach_MaSach",
                table: "ChiTietMuon",
                column: "MaSach",
                principalTable: "Sach",
                principalColumn: "MaSach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietMuon_Sach_MaSach",
                table: "ChiTietMuon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sach",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietMuon_MaSach",
                table: "ChiTietMuon");

            migrationBuilder.DropColumn(
                name: "MaSach",
                table: "Sach");

            migrationBuilder.DropColumn(
                name: "MaSach",
                table: "ChiTietMuon");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sach",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Sach_Id",
                table: "ChiTietMuon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sach",
                table: "Sach",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMuon_Sach_Id",
                table: "ChiTietMuon",
                column: "Sach_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietMuon_Sach_Sach_Id",
                table: "ChiTietMuon",
                column: "Sach_Id",
                principalTable: "Sach",
                principalColumn: "Id");
        }
    }
}
