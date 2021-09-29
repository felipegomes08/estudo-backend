using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiBackendPI.Migrations
{
    public partial class PopulaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[] { 1, "felipe@gmail.com", "Felipe Gomes", "123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[] { 2, "wilson@gmail.com", "Wilson Assis", "456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Nome", "Senha" },
                values: new object[] { 3, "itallo@gmail.com", "Itallo Andrade", "789" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
