using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // To add this I opened PM console
            // ran 'add-migration CreateDatabase'
            // then 'update-database'
            // or from PS:
            // dotnet-ef database update --project .\HiddenVilla_Server\
            // run the app: dotnet watch run --project .\HiddenVilla_Server\ -debug
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
