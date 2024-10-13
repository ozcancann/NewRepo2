using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class DashboardController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public ActionResult Index()
        {

            ViewBag.EducationCount = context.Education.Count();
            ViewBag.InternshipCount = context.Internship.Count();
            ViewBag.ExperienceCount = context.Experience.Count();
            ViewBag.MessageCount = context.Contact.Count();
            ViewBag.ServiceCount = context.Service.Count();
            ViewBag.SkillCount = context.Skill.Count();
            ViewBag.SocialMediaCount = context.SocialMedia.Count();
            ViewBag.ServiceCount = context.Service.Count();
            
           
            return View();
        }


    }
}