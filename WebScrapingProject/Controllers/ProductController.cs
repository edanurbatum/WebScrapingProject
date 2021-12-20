using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebScrapingProject.Models;

namespace WebProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            var web = new HtmlWeb();
            var doc = web.Load("https://www.sahibinden.com/kiralik");

            foreach (var item in doc.DocumentNode.SelectNodes("//tr[@class='searchResultsItem     ']"))
            {
                string title = item.ChildNodes[11].ChildNodes[1].InnerText.Trim();
                string link = "https://www.sahibinden.com/" + item.ChildNodes[1].ChildNodes[1].GetAttributeValue("href", "").Trim();
                string img = item.ChildNodes[1].ChildNodes[1].ChildNodes[1].GetAttributeValue("src", "").Trim();
                products.Add(new Product()
                {
                    title = title,
                    link = link,
                    image = img
                });
            }



            return View(products);
        }
    }
}