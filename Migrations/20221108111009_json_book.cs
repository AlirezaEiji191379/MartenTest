using ApiTest.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiTest.Migrations
{
    public partial class json_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Book_BookId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Users_BookId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Users");

            migrationBuilder.AddColumn<Book>(
                name: "Book",
                table: "Users",
                type: "jsonb",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_BookId",
                table: "Users",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Book_BookId",
                table: "Users",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
