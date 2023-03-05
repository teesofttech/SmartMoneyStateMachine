using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMoneyStateMachine.API.Migrations
{
    /// <inheritdoc />
    public partial class firstmigratiom2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerForgotPasswordState");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerForgotPasswordState",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
