using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSeller.DAL.Migrations.UserDb
{
    /// <inheritdoc />
    public partial class Addclientrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "265bc912-6310-4ff4-bb09-cf2bd3b21591");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "ef0ef35d-8091-45d0-9435-d1db4496e47a", "client", "CLIENT" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0ab257-2160-4bed-b12d-bc03701ac09f", "AQAAAAEAACcQAAAAEJdJd2jTaI6sr2sclGKHfJMa3Vva5DpE4FceMfhXn6G+Y3flMMrGd01gySg4GJGRpA==", "1b420ff5-c688-45e4-800a-375cebcf38ce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "2737f4fe-2dfd-4d1a-a044-8247732dc61e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "472550da-457b-4868-96bb-4c7d6bd23313", "AQAAAAEAACcQAAAAEFlBRfzDup4zXjuYK8nYYS+BtSNqvfWC26nAauKk/Eb76rLJiXXF7U/4B8us2ajJOQ==", "3a572561-f2e4-4cdd-9df2-f4e6dc852fd8" });
        }
    }
}
