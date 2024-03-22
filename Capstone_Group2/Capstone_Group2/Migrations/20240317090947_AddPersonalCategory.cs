using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone_Group2.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonalCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Categories",
               columns: new[] { "CategoryId", "CategoryName" },
               values: new object[] { 3, "Personal" }); // Add the "Personal" category

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
