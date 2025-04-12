using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AlterarSchemaParaTembo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tembo");

            migrationBuilder.RenameTable(
                name: "Tratamentos",
                newName: "Tratamentos",
                newSchema: "tembo");

            migrationBuilder.RenameTable(
                name: "CabeloTratamento",
                newName: "CabeloTratamento",
                newSchema: "tembo");

            migrationBuilder.RenameTable(
                name: "Cabelos",
                newName: "Cabelos",
                newSchema: "tembo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Tratamentos",
                schema: "tembo",
                newName: "Tratamentos");

            migrationBuilder.RenameTable(
                name: "CabeloTratamento",
                schema: "tembo",
                newName: "CabeloTratamento");

            migrationBuilder.RenameTable(
                name: "Cabelos",
                schema: "tembo",
                newName: "Cabelos");
        }
    }
}
