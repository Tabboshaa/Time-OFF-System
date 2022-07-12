using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Time_OFF_System.Migrations
{
    public partial class updateRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_EmployeeId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AspNetUsers_EmployeeId",
                table: "Requests");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Requests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AspNetUsers_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
