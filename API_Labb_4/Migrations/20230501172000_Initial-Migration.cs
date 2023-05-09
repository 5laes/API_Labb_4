using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Labb_4.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HobbieLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HobbieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbieLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HobbieLinks_Hobbies_HobbieId",
                        column: x => x.HobbieId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbieLinks_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "HobbieName" },
                values: new object[,]
                {
                    { 1, "Making music with sound", "Music" },
                    { 2, "Getting that good K/D score", "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Claes", "123123123" },
                    { 2, "Alex", "456456456" },
                    { 3, "Krille", "789789789" },
                    { 4, "Linus", "147147147" }
                });

            migrationBuilder.InsertData(
                table: "HobbieLinks",
                columns: new[] { "Id", "HobbieId", "Link", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "Link to drums", 1 },
                    { 2, 1, "Link to guitars", 2 },
                    { 3, 2, "Link to Counter Strike", 3 },
                    { 4, 2, "Link to Farming Simulator", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HobbieLinks_HobbieId",
                table: "HobbieLinks",
                column: "HobbieId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbieLinks_PersonId",
                table: "HobbieLinks",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbieLinks");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
