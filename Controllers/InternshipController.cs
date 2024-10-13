using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class InternshipController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();

        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternship(Internship internship)
        {
            context.Internship.Add(internship);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }

        public ActionResult DeleteInternship(int id)
        {
            var values = context.Internship.Find(id);
            context.Internship.Remove(values);
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
        [HttpGet]
        public ActionResult UpdateInternship(int id)
        {
            var value = context.Internship.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInternship(Internship internship)
        {
            var values = context.Internship.Find(internship.InternshipId);
            values.CompanyName = internship.CompanyName;
            values.StartDate = internship.StartDate;
            values.EndDate = internship.EndDate;
            values.Position = internship.Position;
            values.Description = internship.Description;
            context.SaveChanges();
            return RedirectToAction("InternshipList");
        }
    }
}