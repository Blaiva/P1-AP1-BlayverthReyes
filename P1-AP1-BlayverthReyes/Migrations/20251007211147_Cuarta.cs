using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_AP1_BlayverthReyes.Migrations
{
    /// <inheritdoc />
    public partial class Cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "EntradasHuacales",
                newName: "Importe");

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalle_EntradasHuacales_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalle_EntradaId",
                table: "EntradasHuacalesDetalle",
                column: "EntradaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesDetalle");

            migrationBuilder.RenameColumn(
                name: "Importe",
                table: "EntradasHuacales",
                newName: "Precio");
        }
    }
}
