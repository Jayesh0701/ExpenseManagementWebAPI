using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeInColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDescription",
                table: "CoreExpenseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseCategory",
                table: "CoreExpenseDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseCategory",
                table: "CoreExpenseDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseDescription",
                table: "CoreExpenseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
