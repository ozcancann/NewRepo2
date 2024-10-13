using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class GraphController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var skills = context.Skill.ToList();

            ViewBag.SkillNames = skills.Select(x => x.SkillName).ToList();
            ViewBag.SkillRates = skills.Select(x => x.Rate).ToList();

            return View();
        }
    }
}