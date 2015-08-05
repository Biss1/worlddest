using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldDestinationsWebApi.Models;

namespace WorldDestinationsWebApi.Controllers
{
    public class PlaceController : ApiController
    {
        private static List<Place> Places = new List<Place>();
        private static List<Place1> Places1 = new List<Place1>();

        // GET /api/place
        public IEnumerable<Place1> Get()
        {
            Places1 = new List<Place1>();
            Places = WorldDestinationsRepository.WorldDestinations.Places.ToList();
            Place1 newPlace;
            foreach (Place p in Places)
            {
                newPlace = new Place1();
                newPlace.Name = p.Name;
                newPlace.Description = p.Description;
                newPlace.ImageURL = p.MainPictureURL;
                newPlace.PlaceID = p.PlaceID;
                newPlace.Continent = p.Continent;
                newPlace.Country = p.Country;
                newPlace.Place = p.Place1;
                newPlace.State = p.State;
                newPlace.CategoryID = p.CategoryID.ToString();
                newPlace.AltPictureURL = p.AltPictureURL;
                Places1.Add(newPlace);
            }
            return Places1;
        }

        // GET /api/product/5
        public Place1 Get(int id)
        {
            //  return List.SingleOrDefault(p => p.ProductID == id);
            return Places1[id];
        }

        // POST /api/place
        public string Post(Place1 newPlace1)
        {
            Place newPlace = new Place();
            newPlace.Name = newPlace1.Name;
            newPlace.Description = newPlace1.Description;
            newPlace.MainPictureURL = newPlace1.ImageURL;
            newPlace.State = newPlace1.State;
            newPlace.Continent = newPlace1.Continent;
            newPlace.Country = newPlace1.Country;
            newPlace.Place1 = newPlace1.Place;
            newPlace.CategoryID = newPlace1.CategoryID;
            newPlace.AltPictureURL = newPlace1.AltPictureURL;
            WorldDestinationsRepository.WorldDestinations.Places.Add(newPlace);
            try
            {
                WorldDestinationsRepository.WorldDestinations.SaveChanges();
                int placeID = WorldDestinationsRepository.WorldDestinations.Places.FirstOrDefault(x => x.Name == newPlace1.Name).PlaceID;
                return placeID.ToString();
            }
            catch (Exception e)
            {
                return "NO";
            }

        }

        // PUT /api/product/5
        public void Put(Place1 value)
        {

        
        }

        // DELETE /api/product/5
        public void Delete(int id)
        {
          //not implemented
        }


    }
}
