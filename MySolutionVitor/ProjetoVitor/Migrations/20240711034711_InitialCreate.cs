using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoVitor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carritos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Marca = table.Column<string>(type: "TEXT", nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", nullable: true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Em = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carritos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carritos");
        }
    }
}
