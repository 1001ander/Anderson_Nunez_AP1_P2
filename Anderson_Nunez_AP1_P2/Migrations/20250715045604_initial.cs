using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anderson_Nunez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false),
                    EsCompuesto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    EntradaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<int>(type: "int", nullable: false),
                    ProductosProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_Entradas_Productos_ProductosProductoId",
                        column: x => x.ProductosProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "EntradasDetalles",
                columns: table => new
                {
                    EntradaDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntradaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasDetalles", x => x.EntradaDetalleId);
                    table.ForeignKey(
                        name: "FK_EntradasDetalles_Entradas_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "EntradaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_ProductosProductoId",
                table: "Entradas",
                column: "ProductosProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasDetalles_EntradaId",
                table: "EntradasDetalles",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasDetalles_ProductoId",
                table: "EntradasDetalles",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasDetalles");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
