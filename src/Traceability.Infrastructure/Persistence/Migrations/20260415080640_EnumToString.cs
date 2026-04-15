using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traceability.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EnumToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductionEventType",
                table: "ProductionEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "ProductionData",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductionEventType",
                table: "ProductionEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "ProductionData");
        }
    }
}
