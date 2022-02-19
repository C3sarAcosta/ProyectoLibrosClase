using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoLibros.Migrations
{
    public partial class CampoNacionalidadAutores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Autores",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Autores");
        }
    }
}
