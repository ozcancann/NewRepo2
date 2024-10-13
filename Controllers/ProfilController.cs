using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ProfilController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();

        public ActionResult ProfileIndex()
        {
            var values = context.Profile.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var values = context.Profile.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProfile(Profile profile)
        {
            var values = context.Profile.Find(profile.ProfileId);

            values.Birthdate = profile.Birthdate;
            values.Email = profile.Email;
            values.PhoneNumber = profile.PhoneNumber;
            values.Github = profile.Github;
            values.Address = profile.Address;
            values.Title = profile.Title;
            values.Description = profile.Description;
            values.ImageUrl = profile.ImageUrl;

            context.SaveChanges();
            return RedirectToAction("ProfileIndex");
        }
    }
}