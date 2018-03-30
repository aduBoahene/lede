using System;
using System.Collections.Generic;
using System.Text;

namespace ledeModels.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public String Title { get; set; }
        public String GenreName { get; set; }
        public String Synopsis { get; set; }
        public String PosterUrl { get; set; }
        public String TrailerUrl { get; set; }
        public String Amount { get; set; }
        public String HouseName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int HouseId { get; set; }
    }
}
