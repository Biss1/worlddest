using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldDestinationsWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SelectCategory();
            return View();
        }
        public void SelectCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Category cat in WorldDestinationsRepository.WorldDestinations.Categories)
            {
                items.Add(new SelectListItem { Text = cat.Name, Value = cat.CategoryID });
            }

            ViewBag.Categories = items;
        }


        public ViewResult CategoryChosen(Place newPlace)
        {
            SelectCategory();
            if (ModelState.IsValid)
            {
                WorldDestinationsRepository.WorldDestinations.Places.Add(newPlace);

            }
            try
            {
                WorldDestinationsRepository.WorldDestinations.SaveChanges();
                ViewData["message"] = "SUCCESS";
            }
            catch (Exception e)
            {
                ViewData["message"] = "NOT SUCCESSFUL";
            }

            return View("Index");

        }
    }
}
