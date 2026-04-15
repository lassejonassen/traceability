using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traceability.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PS_ProcessSegmentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProcessSegments",
                newName: "ProcessSegmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProcessSegmentId",
                table: "ProcessSegments",
                newName: "Name");
        }
    }
}
