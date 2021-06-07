using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore.Bookstore.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 742, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 744, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 744, DateTimeKind.Local).AddTicks(1790));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 744, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 744, DateTimeKind.Local).AddTicks(1793));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2021, 6, 7, 9, 11, 43, 744, DateTimeKind.Local).AddTicks(1795));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 537, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7448));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "ID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2019, 9, 4, 10, 24, 11, 538, DateTimeKind.Local).AddTicks(7483));
        }
    }
}
