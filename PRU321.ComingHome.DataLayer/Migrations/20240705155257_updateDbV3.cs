using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRU321.ComingHome.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class updateDbV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentSpeed",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentSpeed",
                table: "Users");
        }
    }
}
