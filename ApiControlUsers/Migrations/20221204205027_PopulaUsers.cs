using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiControlUsers.Migrations
{
    public partial class PopulaUsers : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Users(Name, Email) Values('Jorge', 'jorgepereira29ele@gmail.com')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Users");
        }
    }
}
