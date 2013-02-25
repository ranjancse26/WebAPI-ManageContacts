using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi_ManageContacts.Models;

namespace WebApi_ManageContacts.Database
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
            : base("name=ContactsDbContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}