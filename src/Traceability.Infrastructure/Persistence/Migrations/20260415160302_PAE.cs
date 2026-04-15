using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traceability.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PAE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionEventAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumericValue = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ProductionEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAtUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionEventAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionEventAttributes_ProductionEvents_ProductionEventId",
                        column: x => x.ProductionEventId,
                        principalTable: "ProductionEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionEventAttributes_ProductionEventId",
                table: "ProductionEventAttributes",
                column: "ProductionEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionEventAttributes");
        }
    }
}
