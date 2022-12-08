using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSeller.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingAdresstodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Contry = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}
