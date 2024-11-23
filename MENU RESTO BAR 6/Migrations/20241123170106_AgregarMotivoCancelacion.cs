using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MENU_RESTO_BAR_6.Migrations
{
    /// <inheritdoc />
    public partial class AgregarMotivoCancelacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla de MotivosCancelacion
            migrationBuilder.CreateTable(
                name: "MotivosCancelacion",
                columns: table => new
                {
                    MotivoCancelacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosCancelacion", x => x.MotivoCancelacionId);
                });

            // Insertar datos en MotivosCancelacion
            migrationBuilder.InsertData(
                table: "MotivosCancelacion",
                columns: new[] { "MotivoCancelacionId", "Descripcion" },
                values: new object[,]
                {
            { 1, "Cambio de planes" },
            { 2, "Emergencia personal" },
            { 3, "Problemas de horario" },
            { 4, "Otro motivo" }
                });

            // Agregar columnas a Reservas
            migrationBuilder.AddColumn<bool>(
                name: "EstaCancelada",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MotivoCancelacionId",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotivoCancelacionOtro",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);

            // Crear índice para la clave foránea
            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MotivoCancelacionId",
                table: "Reservas",
                column: "MotivoCancelacionId");

            // Agregar clave foránea
            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_MotivosCancelacion_MotivoCancelacionId",
                table: "Reservas",
                column: "MotivoCancelacionId",
                principalTable: "MotivosCancelacion",
                principalColumn: "MotivoCancelacionId");
        }



    }
}
