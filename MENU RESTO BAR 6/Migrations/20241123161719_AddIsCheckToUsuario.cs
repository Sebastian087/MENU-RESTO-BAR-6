using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MENU_RESTO_BAR_6.Migrations
{
    /// <inheritdoc />
    public partial class AddIsCheckToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCheck",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCheck",
                table: "Usuarios");
        }
    }
}
