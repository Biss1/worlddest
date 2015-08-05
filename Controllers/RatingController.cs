using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldDestinationsWebApi.Models;

namespace WorldDestinationsWebApi.Controllers
{
    public class RatingController : ApiController
    {
        // GET api/rating
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/rating/5
        public IEnumerable<Rating> Get(int id)
        {
            List<UserRating> ratings = WorldDestinationsRepository.WorldDestinations.UserRatings.ToList().Where(m=>m.PlaceID==id).ToList() ;
            List<Rating> ratingss = new List<Rating>();
            Rating rating;
            foreach (UserRating r in ratings)
            {
                rating = new Rating();
                rating.UserName = r.UserName;
                rating.RatingID = r.Id;
                rating.Comment = r.Comment;
                rating.Ratingg =(short) r.Rating;
                ratingss.Add(rating);
            }
            return ratingss;
        }

        // POST api/rating
        public string Post(Rating rating)
        {
            UserRating newRating = new UserRating();
            newRating.Comment = rating.Comment;
            newRating.PlaceID = rating.PlaceID;
            newRating.Rating = rating.Ratingg;
            newRating.UserName = rating.UserName;
           
            WorldDestinationsRepository.WorldDestinations.UserRatings.Add(newRating);
            try
            {
                WorldDestinationsRepository.WorldDestinations.SaveChanges();
                return "YES";
            }
            catch (Exception e)
            {
                return "NO";
            }

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}