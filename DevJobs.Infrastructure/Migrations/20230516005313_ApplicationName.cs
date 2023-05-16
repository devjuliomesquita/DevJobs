using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevJobs.Infrastructure.Migrations
{
    public partial class ApplicationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicatName",
                table: "tb_Application",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_Application",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_Application",
                newName: "ApplicatName");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicatName",
                table: "tb_Application",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }
    }
}
