using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProject.Controllers
{
    public class StatsController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = context.Contact.Count();

            ViewBag.messageIsReadTrueCount = context.Contact.Where(x => x.IsRead == true).Count();

            ViewBag.messageIsReadFalseCount = context.Contact.Where(x => x.IsRead == false).Count();

            ViewBag.skillCount = context.Skill.Count();

            ViewBag.skillRateSum = context.Skill.Sum(x => x.Rate);

            ViewBag.skillRateAvg = context.Skill.Average(x => x.Rate);

            var maxValues = context.Skill.Max(x => x.Rate);
            ViewBag.maxRateSkillName = context.Skill.Where(x => x.Rate == maxValues).Select(x => x.SkillName).FirstOrDefault();

            ViewBag.getMessageCountBySubjectReferences = context.Contact.Where(x => x.Subject == "Referans").Count();

            ViewBag.getMessageCountByEmailContainAAndIsReadTrue = context.Contact.Where(x => x.IsRead == true && x.Email.Contains("A")).Count();

            ViewBag.getSkillNameByRate80 = context.Skill.Where(x => x.Rate == 80).Select(x => x.SkillName).FirstOrDefault();

            return View();
        }
    }
}