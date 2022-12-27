using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmApi.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Strawberry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Label = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Spec = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InitialState = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Situation = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BornFrom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strawberry", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StrawberryLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CurrentState = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenderLeaves = table.Column<int>(type: "int", nullable: false),
                    OldLeaves = table.Column<int>(type: "int", nullable: false),
                    FlowerBud = table.Column<int>(type: "int", nullable: false),
                    LeavesBud = table.Column<int>(type: "int", nullable: false),
                    Flower = table.Column<int>(type: "int", nullable: false),
                    Fruit = table.Column<int>(type: "int", nullable: false),
                    IsRepotting = table.Column<int>(type: "int", nullable: false),
                    IsPruning = table.Column<int>(type: "int", nullable: false),
                    IsFertilize = table.Column<int>(type: "int", nullable: false),
                    StrawberryId = table.Column<long>(type: "bigint", nullable: false),
                    Stolon = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrawberryLog", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Strawberry_CreatedAt",
                table: "Strawberry",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Strawberry_Label",
                table: "Strawberry",
                column: "Label");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_CreatedAt",
                table: "StrawberryLog",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_Flower",
                table: "StrawberryLog",
                column: "Flower");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_FlowerBud",
                table: "StrawberryLog",
                column: "FlowerBud");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_Fruit",
                table: "StrawberryLog",
                column: "Fruit");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_IsFertilize",
                table: "StrawberryLog",
                column: "IsFertilize");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_IsPruning",
                table: "StrawberryLog",
                column: "IsPruning");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_IsRepotting",
                table: "StrawberryLog",
                column: "IsRepotting");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_LeavesBud",
                table: "StrawberryLog",
                column: "LeavesBud");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_OldLeaves",
                table: "StrawberryLog",
                column: "OldLeaves");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_Stolon",
                table: "StrawberryLog",
                column: "Stolon");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_StrawberryId",
                table: "StrawberryLog",
                column: "StrawberryId");

            migrationBuilder.CreateIndex(
                name: "IX_StrawberryLog_TenderLeaves",
                table: "StrawberryLog",
                column: "TenderLeaves");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Strawberry");

            migrationBuilder.DropTable(
                name: "StrawberryLog");
        }
    }
}
