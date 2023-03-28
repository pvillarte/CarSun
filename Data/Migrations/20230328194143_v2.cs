using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSun.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cubicaje = table.Column<int>(type: "int", nullable: true),
                    Especificacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Cilindros = table.Column<int>(type: "int", nullable: true),
                    Valvulas = table.Column<int>(type: "int", nullable: true),
                    Tipo_Motor = table.Column<int>(type: "int", nullable: false),
                    Hibridacion = table.Column<int>(type: "int", nullable: false),
                    Configuracion = table.Column<int>(type: "int", nullable: true),
                    Alimentacion = table.Column<int>(type: "int", nullable: false),
                    Sobrealimentacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Marca_Id = table.Column<int>(type: "int", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Marcas_Marca_Id",
                        column: x => x.Marca_Id,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Generaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iteracion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Serie_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generaciones_Series_Serie_Id",
                        column: x => x.Serie_Id,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plazas = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Carroceria = table.Column<int>(type: "int", nullable: false),
                    Maletero = table.Column<int>(type: "int", nullable: false),
                    Largo = table.Column<int>(type: "int", nullable: false),
                    Ancho = table.Column<int>(type: "int", nullable: false),
                    Alto = table.Column<int>(type: "int", nullable: false),
                    Serie_Id = table.Column<int>(type: "int", nullable: false),
                    Generacion_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Generaciones_Generacion_Id",
                        column: x => x.Generacion_Id,
                        principalTable: "Generaciones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Modelos_Series_Serie_Id",
                        column: x => x.Serie_Id,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acabados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acabados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acabados_Modelos_Modelo_Id",
                        column: x => x.Modelo_Id,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modelos_Motores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Potencia = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    RPM_Potencia = table.Column<int>(type: "int", nullable: false),
                    RPM_Par = table.Column<int>(type: "int", nullable: false),
                    Aceleracion = table.Column<int>(type: "int", nullable: false),
                    Velocidad_Maxima = table.Column<int>(type: "int", nullable: false),
                    Deposito = table.Column<int>(type: "int", nullable: false),
                    Motor_Id = table.Column<int>(type: "int", nullable: false),
                    Modelo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos_Motores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Motores_Modelos_Modelo_Id",
                        column: x => x.Modelo_Id,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Modelos_Motores_Motores_Motor_Id",
                        column: x => x.Motor_Id,
                        principalTable: "Motores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acabados_Equipamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opcional = table.Column<bool>(type: "bit", nullable: false),
                    Acabado_Id = table.Column<int>(type: "int", nullable: false),
                    Equipamiento_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acabados_Equipamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acabados_Equipamientos_Acabados_Acabado_Id",
                        column: x => x.Acabado_Id,
                        principalTable: "Acabados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acabados_Equipamientos_Equipamientos_Equipamiento_Id",
                        column: x => x.Equipamiento_Id,
                        principalTable: "Equipamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etiqueta = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Kms = table.Column<int>(type: "int", nullable: false),
                    Traccion = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cambio = table.Column<int>(type: "int", nullable: false),
                    Relaciones = table.Column<int>(type: "int", nullable: true),
                    Motor_Id = table.Column<int>(type: "int", nullable: false),
                    Modelo_Id = table.Column<int>(type: "int", nullable: false),
                    Acabado_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Acabados_Acabado_Id",
                        column: x => x.Acabado_Id,
                        principalTable: "Acabados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehiculos_Modelos_Modelo_Id",
                        column: x => x.Modelo_Id,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Motores_Motor_Id",
                        column: x => x.Motor_Id,
                        principalTable: "Motores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NEDCs",
                columns: table => new
                {
                    Modelo_Motor_Id = table.Column<int>(type: "int", nullable: false),
                    Ciclo_Urbano = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Extraurbano = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Combinado = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Emisiones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NEDCs", x => x.Modelo_Motor_Id);
                    table.ForeignKey(
                        name: "FK_NEDCs_Modelos_Motores_Modelo_Motor_Id",
                        column: x => x.Modelo_Motor_Id,
                        principalTable: "Modelos_Motores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WLTPs",
                columns: table => new
                {
                    Modelo_Motor_Id = table.Column<int>(type: "int", nullable: false),
                    Ciclo_Bajo = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Medio = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Alto = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Extra_Alto = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Ciclo_Combinado = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                    Emisiones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WLTPs", x => x.Modelo_Motor_Id);
                    table.ForeignKey(
                        name: "FK_WLTPs_Modelos_Motores_Modelo_Motor_Id",
                        column: x => x.Modelo_Motor_Id,
                        principalTable: "Modelos_Motores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamientos_Vehiculos",
                columns: table => new
                {
                    Equipamiento_Id = table.Column<int>(type: "int", nullable: false),
                    Vehiculo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamientos_Vehiculos", x => new { x.Equipamiento_Id, x.Vehiculo_Id });
                    table.ForeignKey(
                        name: "FK_Equipamientos_Vehiculos_Equipamientos_Equipamiento_Id",
                        column: x => x.Equipamiento_Id,
                        principalTable: "Equipamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamientos_Vehiculos_Vehiculos_Vehiculo_Id",
                        column: x => x.Vehiculo_Id,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acabados_Modelo_Id",
                table: "Acabados",
                column: "Modelo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Acabados_Equipamientos_Acabado_Id",
                table: "Acabados_Equipamientos",
                column: "Acabado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Acabados_Equipamientos_Equipamiento_Id",
                table: "Acabados_Equipamientos",
                column: "Equipamiento_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamientos_Vehiculos_Vehiculo_Id",
                table: "Equipamientos_Vehiculos",
                column: "Vehiculo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Generaciones_Serie_Id",
                table: "Generaciones",
                column: "Serie_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Generacion_Id",
                table: "Modelos",
                column: "Generacion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Serie_Id",
                table: "Modelos",
                column: "Serie_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Motores_Modelo_Id",
                table: "Modelos_Motores",
                column: "Modelo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_Motores_Motor_Id",
                table: "Modelos_Motores",
                column: "Motor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Series_Marca_Id",
                table: "Series",
                column: "Marca_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Acabado_Id",
                table: "Vehiculos",
                column: "Acabado_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Modelo_Id",
                table: "Vehiculos",
                column: "Modelo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Motor_Id",
                table: "Vehiculos",
                column: "Motor_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acabados_Equipamientos");

            migrationBuilder.DropTable(
                name: "Equipamientos_Vehiculos");

            migrationBuilder.DropTable(
                name: "NEDCs");

            migrationBuilder.DropTable(
                name: "WLTPs");

            migrationBuilder.DropTable(
                name: "Equipamientos");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Modelos_Motores");

            migrationBuilder.DropTable(
                name: "Acabados");

            migrationBuilder.DropTable(
                name: "Motores");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Generaciones");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
