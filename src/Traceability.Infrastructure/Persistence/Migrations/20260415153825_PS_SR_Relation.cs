using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traceability.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PS_SR_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SegmentId",
                table: "SegmentResponses",
                newName: "SegmentResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_SegmentResponses_ProcessSegmentId",
                table: "SegmentResponses",
                column: "ProcessSegmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SegmentResponses_ProcessSegments_ProcessSegmentId",
                table: "SegmentResponses",
                column: "ProcessSegmentId",
                principalTable: "ProcessSegments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SegmentResponses_ProcessSegments_ProcessSegmentId",
                table: "SegmentResponses");

            migrationBuilder.DropIndex(
                name: "IX_SegmentResponses_ProcessSegmentId",
                table: "SegmentResponses");

            migrationBuilder.RenameColumn(
                name: "SegmentResponseId",
                table: "SegmentResponses",
                newName: "SegmentId");
        }
    }
}
