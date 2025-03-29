using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineRecommendationMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WineSamples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedAcidity = table.Column<float>(type: "real", nullable: false),
                    VolatileAcidity = table.Column<float>(type: "real", nullable: false),
                    CitricAcid = table.Column<float>(type: "real", nullable: false),
                    ResidualSugar = table.Column<float>(type: "real", nullable: false),
                    Chlorides = table.Column<float>(type: "real", nullable: false),
                    FreeSulfurDioxide = table.Column<float>(type: "real", nullable: false),
                    TotalSulfurDioxide = table.Column<float>(type: "real", nullable: false),
                    Density = table.Column<float>(type: "real", nullable: false),
                    PH = table.Column<float>(type: "real", nullable: false),
                    Sulphates = table.Column<float>(type: "real", nullable: false),
                    Alcohol = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineSamples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WinePredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredictedQuality = table.Column<float>(type: "real", nullable: false),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WineSampleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinePredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WinePredictions_WineSamples_WineSampleId",
                        column: x => x.WineSampleId,
                        principalTable: "WineSamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinePredictions_WineSampleId",
                table: "WinePredictions",
                column: "WineSampleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinePredictions");

            migrationBuilder.DropTable(
                name: "WineSamples");
        }
    }
}
