using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "permission_id_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "user_id_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Organization = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<long>(maxLength: 10, nullable: false),
                    BillingAddress = table.Column<string>(maxLength: 500, nullable: true),
                    CreditCardNumber = table.Column<long>(maxLength: 15, nullable: false),
                    ExpirationDate = table.Column<string>(nullable: true),
                    CVV = table.Column<int>(maxLength: 5, nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInformation_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_PermissionId",
                table: "UserInformation",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInformation");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropSequence(
                name: "permission_id_hilo");

            migrationBuilder.DropSequence(
                name: "user_id_hilo");
        }
    }
}
