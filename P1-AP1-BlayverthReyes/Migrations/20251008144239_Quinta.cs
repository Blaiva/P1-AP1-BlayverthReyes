using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P1_AP1_BlayverthReyes.Migrations
{
    /// <inheritdoc />
    public partial class Quinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasHuacalesDetalle_EntradasHuacales_EntradaId",
                table: "EntradasHuacalesDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradasHuacalesDetalle",
                table: "EntradasHuacalesDetalle");

            migrationBuilder.RenameTable(
                name: "EntradasHuacalesDetalle",
                newName: "EntradasHuacalesDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_EntradasHuacalesDetalle_EntradaId",
                table: "EntradasHuacalesDetalles",
                newName: "IX_EntradasHuacalesDetalles_EntradaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradasHuacalesDetalles",
                table: "EntradasHuacalesDetalles",
                column: "DetalleId");

            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Rojo Pequeño", 0 },
                    { 2, "Verde Pequeño", 0 },
                    { 3, "Rojo Mediano", 0 },
                    { 4, "Verde Mediano", 0 },
                    { 5, "Rojo Grande", 0 },
                    { 6, "Verde Grande", 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasHuacalesDetalles_EntradasHuacales_EntradaId",
                table: "EntradasHuacalesDetalles",
                column: "EntradaId",
                principalTable: "EntradasHuacales",
                principalColumn: "IdEntrada",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasHuacalesDetalles_EntradasHuacales_EntradaId",
                table: "EntradasHuacalesDetalles");

            migrationBuilder.DropTable(
                name: "TiposHuacales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradasHuacalesDetalles",
                table: "EntradasHuacalesDetalles");

            migrationBuilder.RenameTable(
                name: "EntradasHuacalesDetalles",
                newName: "EntradasHuacalesDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_EntradasHuacalesDetalles_EntradaId",
                table: "EntradasHuacalesDetalle",
                newName: "IX_EntradasHuacalesDetalle_EntradaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradasHuacalesDetalle",
                table: "EntradasHuacalesDetalle",
                column: "DetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasHuacalesDetalle_EntradasHuacales_EntradaId",
                table: "EntradasHuacalesDetalle",
                column: "EntradaId",
                principalTable: "EntradasHuacales",
                principalColumn: "IdEntrada",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
