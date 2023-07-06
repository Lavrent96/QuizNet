using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargooReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceProviderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentContainers_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pieces = table.Column<int>(type: "int", nullable: true),
                    Packages = table.Column<int>(type: "int", nullable: true),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentItems_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentRemarks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemarkTemplateId = table.Column<long>(type: "bigint", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRemarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentRemarks_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stuffings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SealNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuffings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stuffings_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ShipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transports_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "CargooReference", "ServiceProviderName" },
                values: new object[,]
                {
                    { 1, "C2023001999", "Service Provider 1" },
                    { 2, "C2023001888", "Service Provider 2" },
                    { 3, "C2023001777", "Service Provider 3" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentContainers",
                columns: new[] { "Id", "Number", "OriginalType", "ShipmentId", "Type" },
                values: new object[,]
                {
                    { 1, "N0001", "Open top container", 1, "42GP" },
                    { 2, "N0002", "Double door container", 1, "42GP" },
                    { 3, "N0003", "Double door container", 2, "48GP" },
                    { 4, "N0004", "Double door container", 2, "48GP" },
                    { 5, "N0005", "Double door container", 3, "48GP" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentItems",
                columns: new[] { "Id", "ArticleCode", "ArticleDescription", "CommodityCode", "PackageType", "Packages", "Pieces", "ShipmentId", "Volume" },
                values: new object[,]
                {
                    { 1, "ArticleCode 1", "ArticleDescription 1", "CD", "PT1", 5, 5, 1, 5m },
                    { 2, "ArticleCode 2", "ArticleDescription 2", "CD", "PT1", 5, 15, 2, 15m },
                    { 3, "ArticleCode 3", "ArticleDescription 3", "CD", "PT1", 5, 15, 2, 15m },
                    { 4, "ArticleCode 4", "ArticleDescription 4", "CD", "PT1", 15, 15, 2, 15m },
                    { 5, "ArticleCode 5", "ArticleDescription 5", "CD", "PT4", 15, 15, 3, 15m },
                    { 6, "ArticleCode 6", "ArticleDescription 6", "CD", "PT8", 8, 25, 3, 20m }
                });

            migrationBuilder.InsertData(
                table: "ShipmentRemarks",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Remark", "RemarkTemplateId", "ShipmentId", "UpdatedById", "UpdatedOn" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1459), "Remark", 1L, 1, null, null },
                    { 2L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1463), "Remark 1", 1L, 1, null, null },
                    { 3L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1464), "Remark 2", 1L, 1, null, null },
                    { 4L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1465), "Remark 7", 2L, 2, null, null },
                    { 5L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1467), "Remark 8", 2L, 2, null, null },
                    { 6L, 1L, new DateTime(2023, 7, 5, 7, 48, 32, 23, DateTimeKind.Utc).AddTicks(1468), "Remark 8", 2L, 3, null, null }
                });

            migrationBuilder.InsertData(
                table: "Stuffings",
                columns: new[] { "Id", "SealNumber", "ShipmentId", "TrackerNumber" },
                values: new object[,]
                {
                    { 1, "SealNumber 1", 1, "TrackerNumber 1" },
                    { 2, "SealNumber 2", 1, "TrackerNumber 2" },
                    { 3, "SealNumber 3", 2, "TrackerNumber 3" },
                    { 4, "SealNumber 4", 2, "TrackerNumber 4" },
                    { 5, "SealNumber 5", 3, "TrackerNumber 54" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "Id", "CarrierCode", "ShipmentId", "Type" },
                values: new object[,]
                {
                    { 1, "MAEU", 1, 1 },
                    { 2, "SLMU", 1, 1 },
                    { 3, "SLMU", 1, 2 },
                    { 4, "MAEU", 2, 1 },
                    { 5, "SLMU", 2, 1 },
                    { 6, "SLMU", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentContainers_ShipmentId",
                table: "ShipmentContainers",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItems_ShipmentId",
                table: "ShipmentItems",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRemarks_ShipmentId",
                table: "ShipmentRemarks",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stuffings_ShipmentId",
                table: "Stuffings",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_ShipmentId",
                table: "Transports",
                column: "ShipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentContainers");

            migrationBuilder.DropTable(
                name: "ShipmentItems");

            migrationBuilder.DropTable(
                name: "ShipmentRemarks");

            migrationBuilder.DropTable(
                name: "Stuffings");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
