using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tembo");

            migrationBuilder.CreateTable(
                name: "Cabelos",
                schema: "tembo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Composicao = table.Column<string>(type: "text", nullable: false),
                    Textura = table.Column<string>(type: "text", nullable: false),
                    Forma = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tratamentos",
                schema: "tembo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Beneficios = table.Column<string>(type: "text", nullable: false),
                    Produtos = table.Column<string>(type: "text", nullable: false),
                    Funcao = table.Column<string>(type: "text", nullable: false),
                    Descritivo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabeloTratamento",
                schema: "tembo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CabeloId = table.Column<int>(type: "integer", nullable: false),
                    TratamentoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabeloTratamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabeloTratamento_Cabelos_CabeloId",
                        column: x => x.CabeloId,
                        principalSchema: "tembo",
                        principalTable: "Cabelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabeloTratamento_Tratamentos_TratamentoId",
                        column: x => x.TratamentoId,
                        principalSchema: "tembo",
                        principalTable: "Tratamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabeloTratamento_CabeloId",
                schema: "tembo",
                table: "CabeloTratamento",
                column: "CabeloId");

            migrationBuilder.CreateIndex(
                name: "IX_CabeloTratamento_TratamentoId",
                schema: "tembo",
                table: "CabeloTratamento",
                column: "TratamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabeloTratamento",
                schema: "tembo");

            migrationBuilder.DropTable(
                name: "Cabelos",
                schema: "tembo");

            migrationBuilder.DropTable(
                name: "Tratamentos",
                schema: "tembo");
        }
    }
}
