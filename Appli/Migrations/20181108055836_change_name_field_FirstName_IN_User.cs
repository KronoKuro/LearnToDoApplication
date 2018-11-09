using Microsoft.EntityFrameworkCore.Migrations;

namespace Appli.Migrations
{
    public partial class change_name_field_FirstName_IN_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FitstName",
                table: "AspNetUsers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "FitstName");
        }
    }
}
