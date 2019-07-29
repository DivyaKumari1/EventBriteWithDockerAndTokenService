using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_venue_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "events_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventVenues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Venue = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventVenues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(maxLength: 100, nullable: false),
                    EventCost = table.Column<decimal>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    EventAddress = table.Column<string>(nullable: true),
                    EventCity = table.Column<string>(nullable: true),
                    EventState = table.Column<string>(nullable: true),
                    EventZip = table.Column<int>(nullable: false),
                    EventFavorite = table.Column<bool>(nullable: false),
                    EventTicketsAvailable = table.Column<int>(nullable: false),
                    EventStartDate = table.Column<string>(nullable: true),
                    EventStartTime = table.Column<string>(nullable: true),
                    EventEndDate = table.Column<string>(nullable: true),
                    EventEndTime = table.Column<string>(nullable: true),
                    EventPictureUrl = table.Column<string>(nullable: true),
                    EventUrl = table.Column<string>(nullable: true),
                    EventCategoryId = table.Column<int>(nullable: false),
                    EventVenueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventVenues_EventVenueId",
                        column: x => x.EventVenueId,
                        principalTable: "EventVenues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCategoryId",
                table: "Events",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventVenueId",
                table: "Events",
                column: "EventVenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventVenues");

            migrationBuilder.DropSequence(
                name: "event_category_hilo");

            migrationBuilder.DropSequence(
                name: "event_venue_hilo");

            migrationBuilder.DropSequence(
                name: "events_hilo");
        }
    }
}
