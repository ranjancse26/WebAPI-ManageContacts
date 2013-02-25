using System.Data.Entity.Migrations;

namespace WebApi_ManageContacts.Database
{   
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable("dbo.Contacts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Email = c.String(),
                    Phone = c.String(),
                })
                .PrimaryKey(c => c.Id);
        }

        public override void Down()
        {
            DropIndex("dbo.Contacts", new[] { "Id" });
            DropTable("dbo.Contacts");
        }
    }
}