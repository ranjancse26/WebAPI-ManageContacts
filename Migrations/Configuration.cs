namespace WebApi_ManageContacts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi_ManageContacts.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi_ManageContacts.Database.ContactsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApi_ManageContacts.Database.ContactsDbContext context)
        {
            context.Contacts.AddOrUpdate(a => a.Name,
                new Contact
                {
                    Name = "Ranjan",
                    Email = "ranjancse@gmail.com"
                });
        }
    }
}
