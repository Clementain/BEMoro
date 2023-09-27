using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEMoro.Migrations
{
    /// <inheritdoc />
    public partial class v400 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documento_encargado_EncargadoId",
                table: "documento");

            migrationBuilder.DropIndex(
                name: "IX_documento_EncargadoId",
                table: "documento");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "programaSocial",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Informacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArchivoPdf = table.Column<byte[]>(type: "longblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vecs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vecs");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "programaSocial");

            migrationBuilder.CreateIndex(
                name: "IX_documento_EncargadoId",
                table: "documento",
                column: "EncargadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_documento_encargado_EncargadoId",
                table: "documento",
                column: "EncargadoId",
                principalTable: "encargado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
