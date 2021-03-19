using Microsoft.EntityFrameworkCore.Migrations;

namespace Abgular_API.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 1, "ny@gmail.com", "Nayan Raval", "AP48Hjorg5pBxiySvPvGs13CLAofEX+O81o9VXqsljmTLv9BsrGr74AQsPirvVwceg==" });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 2, "sample@gmail.com", "Fenal", "AI3AaXZSLFauq7wiWEjtA7qRiK6qvkOLQ3M2Yvhs7rKx/NxnLxHIiw/GkPnI+VVjTQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEntities");
        }
    }
}
