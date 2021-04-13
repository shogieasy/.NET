using Microsoft.EntityFrameworkCore.Migrations;

namespace zad3.NET.Migrations
{
    public partial class migracja_zad4_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wynik",
                table: "FizzBuzz",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wynik",
                table: "FizzBuzz",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
