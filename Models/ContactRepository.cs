using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi_ManageContacts.Database;

namespace WebApi_ManageContacts.Models
{
    public class ContactRepository : IContactRepository
    {
        private ContactsDbContext context;

        public ContactRepository()
        {
            context = new ContactsDbContext();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return context.Contacts.ToList();
            }
            catch
            {
                throw;
            }  
        }

        public Contact GetContact(int id)
        {
            try
            {
                return context.Contacts.SingleOrDefault(c => c.Id == id);               
            }
            catch
            {
                throw;
            }  
        }

        public Contact AddContact(Contact item)
        {
            try
            {
                context.Contacts.Add(item);
                context.SaveChanges();
                return item;
            }
            catch
            {
                throw;
            }           
        }

        public bool RemoveContact(int id)
        {
            try
            {
                var contact = context.Contacts.SingleOrDefault(c => c.Id == id);
                if (contact == null)
                    throw new Exception(string.Format("Contact with id: '{0}' not found", id.ToString()));
             
                context.Contacts.Remove(contact);
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            } 
        }

        public bool UpdateContact(int id, Contact item)
        {
           try
            {
                var contact = context.Contacts.SingleOrDefault(c => c.Id == id);
             
                if( contact == null)
                    throw new Exception(string.Format("Contact with id: '{0}' not found", id.ToString()));

                contact.Name = item.Name;
                contact.Email = item.Email;
                contact.Phone = item.Phone;

                context.Entry(contact).State = EntityState.Modified;              
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            } 
        }
    }
}
