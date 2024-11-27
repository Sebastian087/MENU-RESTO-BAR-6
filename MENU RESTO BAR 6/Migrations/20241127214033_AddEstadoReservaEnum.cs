using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MENU_RESTO_BAR_6.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoReservaEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmada",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Reservas");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmada",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
