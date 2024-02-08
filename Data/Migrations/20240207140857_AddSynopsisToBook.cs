using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntertainmentDB.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSynopsisToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Book_Synopsis",
                table: "Media",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Book_Synopsis",
                table: "Media");
        }
    }
}
