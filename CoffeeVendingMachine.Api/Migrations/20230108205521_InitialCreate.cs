using Microsoft.EntityFrameworkCore.Migrations;

namespace StarbucksApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coffeees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffeees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacteristicCoffee",
                columns: table => new
                {
                    CharacteristicsId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoffeesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacteristicCoffee", x => new { x.CharacteristicsId, x.CoffeesId });
                    table.ForeignKey(
                        name: "FK_CharacteristicCoffee_Characteristics_CharacteristicsId",
                        column: x => x.CharacteristicsId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacteristicCoffee_Coffeees_CoffeesId",
                        column: x => x.CoffeesId,
                        principalTable: "Coffeees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characteristics",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "extra cream" });

            migrationBuilder.InsertData(
                table: "Characteristics",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "brown sugar" });

            migrationBuilder.InsertData(
                table: "Characteristics",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "double shot" });

            migrationBuilder.InsertData(
                table: "Coffeees",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Starbucks Latte" });

            migrationBuilder.InsertData(
                table: "Coffeees",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Starbucks Macchiato" });

            migrationBuilder.InsertData(
                table: "Coffeees",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Starbucks Espresso" });

            migrationBuilder.InsertData(
                table: "CharacteristicCoffee",
                columns: new[] { "CharacteristicsId", "CoffeesId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CharacteristicCoffee",
                columns: new[] { "CharacteristicsId", "CoffeesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "CharacteristicCoffee",
                columns: new[] { "CharacteristicsId", "CoffeesId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CharacteristicCoffee",
                columns: new[] { "CharacteristicsId", "CoffeesId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "CharacteristicCoffee",
                columns: new[] { "CharacteristicsId", "CoffeesId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CharacteristicCoffee_CoffeesId",
                table: "CharacteristicCoffee",
                column: "CoffeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacteristicCoffee");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Coffeees");
        }
    }
}
