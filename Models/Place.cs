using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldDestinationsWebApi.Models
{
    public class Place1
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string ImageURL { get; set; }
        public string CategoryID { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string AltPictureURL { get; set; }
    }
}