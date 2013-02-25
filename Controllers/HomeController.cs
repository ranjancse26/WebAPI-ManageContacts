using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_ManageContacts.Api;

namespace WebApi_ManageContacts.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {          
            return View();
        }

        [HttpGet]
        public ActionResult ContactsGrid()
        {
            var contactsController = new ContactsController();
            var contacts = contactsController.Get();
            return PartialView("ContactsGrid",contacts);
        }

        [HttpGet]
        public ActionResult GetContactsById(int id)
        {
            var contactsController = new ContactsController();
            var contacts = contactsController.Get(id);
            return PartialView("EditContact", contacts);
        }
    }
}
