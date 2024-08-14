using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClickBonus_API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Usuarios",
               columns: new[] { "Id", "Nome", "Email" },
               values: new object[,]
               {
                    { 1, "Ulisses", "ulisses@example.com" },
                    { 2, "Debora", "debora@example.com" },
                    { 3, "Sheila", "sheila@example.com" },
                    { 4, "Viny", "viny@example.com" },
                    { 5, "Hermes", "hermes@example.com" }
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
