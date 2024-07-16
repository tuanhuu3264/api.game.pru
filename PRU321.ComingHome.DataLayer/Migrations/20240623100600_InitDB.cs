using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRU321.ComingHome.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPlus = table.Column<bool>(type: "bit", nullable: false),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    Jump = table.Column<double>(type: "float", nullable: false),
                    Dame = table.Column<double>(type: "float", nullable: false),
                    Health = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnyCompleted = table.Column<bool>(type: "bit", nullable: false),
                    TotalScore = table.Column<double>(type: "float", nullable: false),
                    NumberCheckpoint = table.Column<int>(type: "int", nullable: false),
                    CurrentScore = table.Column<double>(type: "float", nullable: false),
                    CurrentTime = table.Column<double>(type: "float", nullable: false),
                    CurrentScale = table.Column<double>(type: "float", nullable: false),
                    CurrentJump = table.Column<double>(type: "float", nullable: false),
                    CurrentDame = table.Column<double>(type: "float", nullable: false),
                    CurrentHealth = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playings_UserId",
                table: "Playings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Playings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
