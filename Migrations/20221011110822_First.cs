using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApp.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherID);
                });

            migrationBuilder.InsertData(
                table: "Weathers",
                columns: new[] { "WeatherID", "City", "Date", "Temperature" },
                values: new object[,]
                {
                    { -8, "Lisboa", "2022-10-08", 22.0 },
                    { -7, "Lisboa", "2022-10-07", 11.0 },
                    { -6, "Lisboa", "2022-10-06", 6.0 },
                    { -5, "Lisboa", "2022-10-05", 14.0 },
                    { -4, "Lisboa", "2022-10-04", 18.0 },
                    { -3, "Lisboa", "2022-10-03", 16.0 },
                    { -2, "Lisboa", "2022-10-02", 14.0 },
                    { -1, "Lisboa", "2022-10-01", 12.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weathers");
        }
    }
}
