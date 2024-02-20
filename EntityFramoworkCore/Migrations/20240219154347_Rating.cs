using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramoworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DepartureCity",
                table: "Flights",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Airplanes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Flights");

            migrationBuilder.AlterColumn<string>(
                name: "DepartureCity",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Airplanes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
