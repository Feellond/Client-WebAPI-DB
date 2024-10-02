using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Shape = table.Column<int>(type: "INTEGER", nullable: false),
                    Dosage = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Country", "CreateDate", "Enabled", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "Россия", new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(714), true, "Завод Жизни", new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(723) },
                    { 2, "Нидерланды", new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(726), true, "Завод Сомнений", new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(726) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "Dosage", "Enabled", "ExpirationDate", "ManufacturerId", "Name", "ReleaseDate", "Shape", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(836), "Только взрослым по 1-2 таблетки в день.", true, new DateTime(2024, 10, 3, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(839), 1, "Хорошоцин", new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(839), 1, new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(836) },
                    { 2, new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(844), "Пей и пожалей.", true, new DateTime(2024, 9, 29, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(846), 2, "Плохоцин", new DateTime(2024, 9, 28, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(846), 3, new DateTime(2024, 9, 30, 13, 43, 0, 665, DateTimeKind.Local).AddTicks(845) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
