using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDestinationsWebApi.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int PlaceID{get; set;}
        public short Ratingg { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
    }
}