using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public ActionResult Inbox(int page = 1)
        {
            var values = context.Contact.ToList().ToPagedList(page, 5);
            return View(values);
        }
        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageDetails(int id = 1)
        {
            var values = context.Contact.Find(id);
            values.IsRead = true;
            context.SaveChanges();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = context.Contact.Find(id);
            context.Contact.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Contact.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateMessage(Contact contact)
        {
            var values = context.Contact.Find(contact.ContactId);
            values.NameSurname = contact.NameSurname;
            values.Email = contact.Email;
            values.Subject = contact.Subject;
            values.Message = contact.Message;           
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
    }
}