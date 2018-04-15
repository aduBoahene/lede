using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ledeModels.Model
{
    public class PostMovie
    {

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public string Synopsis { get; set; }
        public string PosterUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Amount { get; set; }
        public int HouseId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
    }
}
