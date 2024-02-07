using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntertainmentDB.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeDeveloperRequiredInPlatform : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Companies_DeveloperId",
                table: "Platforms");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeveloperId",
                table: "Platforms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Companies_DeveloperId",
                table: "Platforms",
                column: "DeveloperId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Companies_DeveloperId",
                table: "Platforms");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeveloperId",
                table: "Platforms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Companies_DeveloperId",
                table: "Platforms",
                column: "DeveloperId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
