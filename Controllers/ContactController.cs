using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactDetail()
        {
            ViewBag.Address = context.Profile.Select(s => s.Address).FirstOrDefault();
            ViewBag.Description = context.Profile.Select(s => s.Description).FirstOrDefault();
            ViewBag.Phone = context.Profile.Select(s => s.PhoneNumber).FirstOrDefault();
            ViewBag.Email = context.Profile.Select(s => s.Email).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialContactLocation()
        {
            return PartialView();
        }
    }
}