using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevJobs.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Vacancy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", nullable: false),
                    Company = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsRemote = table.Column<bool>(type: "bit", nullable: false),
                    SalaryRange = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Vacancy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    IdJobVacancy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Application_tb_Vacancy_IdJobVacancy",
                        column: x => x.IdJobVacancy,
                        principalTable: "tb_Vacancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Application_IdJobVacancy",
                table: "tb_Application",
                column: "IdJobVacancy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Application");

            migrationBuilder.DropTable(
                name: "tb_Vacancy");
        }
    }
}
