using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSeller.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addpaymentIdinticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentId",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "4e40e60e-f0fd-4a81-9d4c-c15299033f90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a084e87f-842c-484a-9129-ba26a27baa90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44137491-b353-4d1b-801a-dfa12675df16", "AQAAAAEAACcQAAAAEONLORSZn6Rr581Kx/ORS0iOZqDNqub310Az/d3EAe1jLOjevbBP6CebAjrBeHHXPg==", "7ed92caa-6fe5-406d-951d-62898d61a281" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "b16bd4ad-45f0-4486-a06f-0b3997bdef74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c5bee023-2697-4211-b398-9e84c8cb5dd0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f217059-5fd5-420b-9f0b-e779ff0c807d", "AQAAAAEAACcQAAAAEBYGjIE4SidfO8JEpiiPK+c0bjrr3Pd0iETg3QPWNhweup0yf8eMCtujXctvGLDf6A==", "c5efd675-4539-438e-8db3-d201e4cf5605" });
        }
    }
}
