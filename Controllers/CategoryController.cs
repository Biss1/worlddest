using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldDestinationsWebApi.Models;

namespace WorldDestinationsWebApi.Controllers
{
    public class CategoryController : ApiController
    {
        List<Place1> places1 = new List<Place1>();
        List<Category1> categories1 = new List<Category1>();
        // GET /api/product
        public IEnumerable<Category1> Get()
        {
            List<Category> categories = WorldDestinationsRepository.WorldDestinations.Categories.ToList();
            Category1 cat;
            foreach (Category c in categories)
            {
                cat = new Category1();
                cat.Name = c.Name;
                cat.Description = c.Description;
                cat.CategoryID = c.CategoryID;
                cat.ImageURL = c.PictureURL;
                categories1.Add(cat);
            }
            return categories1;
        }

        // GET /api/category/5
        public IEnumerable<Place1> Get(string id)
        {
            //site places od taa kategorija
            List<Place> places = WorldDestinationsRepository.WorldDestinations.Places.Where(p => p.CategoryID == id).ToList();
            Place1 newPlace;
            foreach (Place p in places)
            {
                newPlace = new Place1();
                newPlace.CategoryID = p.CategoryID;
                newPlace.PlaceID = p.PlaceID;
                newPlace.Description = p.Description;
                newPlace.Name = p.Name;
                newPlace.Continent = p.Continent;
                newPlace.Country = p.Country;
                newPlace.State = p.State;
                newPlace.Place = p.Place1;
                newPlace.ImageURL = p.MainPictureURL;
                newPlace.AltPictureURL = p.AltPictureURL;
                places1.Add(newPlace);
            }
            //  return List.SingleOrDefault(p => p.CategoryID == id);
            return places1;
        }

       

    }
}
