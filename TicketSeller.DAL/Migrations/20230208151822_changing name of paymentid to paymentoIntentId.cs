using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSeller.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changingnameofpaymentidtopaymentoIntentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Tickets",
                newName: "PaymentIntentId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "e85acc4b-3d7d-46db-a7fd-a480cb701148");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "18e0182d-3001-4dbb-8cc0-f07e0f4d48a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e4711d6-6ddc-40c9-b92b-5417531963ec", "AQAAAAEAACcQAAAAEJeLjheD7BgpyY4ddoDet58y5CH5ITd63pcPVmwv8XXgoTkaQ2JBSMmuIXEmCRyfeA==", "d8a7e8ce-4e88-4c18-b366-b0f54e175ca8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentIntentId",
                table: "Tickets",
                newName: "PaymentId");

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
    }
}
