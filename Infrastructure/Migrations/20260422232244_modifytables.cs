using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grade_Value",
                table: "Students",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "Email_Value",
                table: "Students",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Students",
                newName: "Grade_Value");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Students",
                newName: "Email_Value");
        }
    }
}
