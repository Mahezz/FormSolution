using FormSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //Creating list from database model "country"
            List<SelectItem> lst = null;

            using (Models.DatabaseEntities1 db = new Models.DatabaseEntities1())
            {
                lst = (from d in db.Country
                                     select new SelectItem
                                     {
                                         Id = d.Id,
                                         CountryName = d.Name
                                     }).ToList();
            }

            //Creating list of <SelectListItem> by giving values from the created list "lst"
            List<SelectListItem> items = lst.ConvertAll(
                d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.CountryName.ToString(),
                        Value = d.CountryName.ToString(),
                        Selected = false
                    };
                });


            //Creating ViewBag that is going to be passed to the view later with all the countries in it
            ViewBag.items = items;

            return View();
        }
    }
}