using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProject.Models;

namespace PortfolioProjectNight.Controllers
{
    public class PortfolioController : Controller
    {
        MyPortfolioEntities context = new MyPortfolioEntities();
        public ActionResult PortfolioList()
        {
            var values = context.Portfolio.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
        public ActionResult DeletePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            context.Portfolio.Remove(value);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var value = context.Portfolio.Find(portfolio.PortfolioId);

            value.SubTitle = portfolio.SubTitle;
            value.Title = portfolio.Title;
            context.SaveChanges();

            return RedirectToAction("PortfolioList");
        }
    }
}