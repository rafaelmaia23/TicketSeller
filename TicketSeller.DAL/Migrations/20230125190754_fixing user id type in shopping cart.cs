using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSeller.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fixinguseridtypeinshoppingcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_IdentityUser_IdentityUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_IdentityUser_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_IdentityUserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "438c2f61-8dd2-4078-b582-54d40ba9a0cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "df8266c2-3360-44e1-880f-288c72bfe4ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "734549e4-bfa8-49cb-b825-c44b1cd9aff4", "AQAAAAEAACcQAAAAEGEteN8u6is6iiqdjzqJ/veexE9TRokL8Oz0Leys6B6/OSa7JropC4OO8F1xoC6fnA==", "9afc0cb2-ce88-4c31-9826-42998d349258" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_IdentityUser_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_IdentityUser_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_IdentityUser_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_IdentityUser_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "ab4ef41c-f174-415a-b744-79c7ce46ed0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "5fa4229a-a34b-4a1e-819b-03a12f4e0f96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b014be9-e5c7-4832-a21c-e927ea540954", "AQAAAAEAACcQAAAAENSlKX8p/gUqCuRIxWAfICIbRbCvhsKQA67UQaao/Y1Mds/KEWnZiap/VMoBaq/1xw==", "7d8cad4f-6da9-42f0-ba2c-240ec551ca7b" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdentityUserId",
                table: "Tickets",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_IdentityUserId",
                table: "ShoppingCarts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_IdentityUser_IdentityUserId",
                table: "ShoppingCarts",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_IdentityUser_IdentityUserId",
                table: "Tickets",
                column: "IdentityUserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}
