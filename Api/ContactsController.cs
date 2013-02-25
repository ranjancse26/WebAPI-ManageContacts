using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_ManageContacts.Models;

namespace WebApi_ManageContacts.Api
{
    public class ContactsController : ApiController
    {
        private static readonly IContactRepository _contacts = new ContactRepository();

        // Get All Contacts
        public IEnumerable<Contact> Get()
        {
            return _contacts.GetAllContacts();
        }

        // Get Contact by Id
        public Contact Get(int id)
        {
            try
            {
                Contact contact = _contacts.GetContact(id);
                return contact;
            }
            catch (Exception ex)
            {
                 throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));                
            }
        }
        
        // Insert Contact
        public HttpResponseMessage Post(Contact value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contact contact = _contacts.AddContact(value);
                    var response = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Model state is invalid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        // Update Contacts
        public HttpResponseMessage Put(int id, Contact value)
        {
            try
            {
                value.Id = id;
                _contacts.UpdateContact(id, value);              
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // Delete Contacts
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _contacts.RemoveContact(id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
