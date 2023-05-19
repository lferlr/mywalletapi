using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyWalletAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddMethodPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MethodPayment",
                table: "Expense",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodPayment",
                table: "Expense");
        }
    }
}
