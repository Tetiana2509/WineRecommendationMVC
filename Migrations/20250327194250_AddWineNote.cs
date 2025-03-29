using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineRecommendationMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddWineNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinePredictionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineNotes_WinePredictions_WinePredictionId",
                        column: x => x.WinePredictionId,
                        principalTable: "WinePredictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineNotes_WinePredictionId",
                table: "WineNotes",
                column: "WinePredictionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WineNotes");
        }
    }
}
