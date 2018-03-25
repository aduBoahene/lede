using ledeHelpers;
using ledeModels.Model;
using ledeModels.ModelResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mawulede_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
    public class MovieController : ApiController
    {
        DBHelper _helper;
        HttpRequestMessage req;

        public MovieController()
        {
            _helper = new ledeHelpers.DBHelper();
        }
        public MovieController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Movie> GetMovieById(int houseId, int MovieId)
        {
            var results = new List<Movie>();
            try
            {
                results = _helper.GetMovieById(houseId, MovieId);
                if (results != null || results.Count > 0)
                {
                    return results;
                }
                else { return null; }

            }
            catch (Exception x)
            {
                return null;
            }
        }

        [HttpGet]
        public List<Movie> GetAllMovie(int houseId)
        {
            var results = new List<Movie>();
            try
            {
                results = _helper.GetAllMovie(houseId);
                if (results != null || results.Count > 0)
                {
                    return results;
                }
                else { return null; }

            }
            catch (Exception x)
            {
                return null;
            }
        }

        public List<ShowMoment> GetMovieTime(int movieId)
        {
            var results = new List<ShowMoment>();
            try
            {
                results = _helper.GetMovieTime(movieId);
                if (results != null || results.Count > 0)
                {
                    return results;
                }
                else { return null; }

            }
            catch (Exception x)
            {
                return null;
            }
        }


        [HttpPost]
        public AjaxResponse PostMovie([FromBody]PostMovie newMovie)
        {
            try
            {
                int prod;
                var httpRequest = HttpContext.Current.Request;
                if (newMovie.Title!=null)
                {
                    prod = _helper.PostMovie(newMovie);
                }

                return new AjaxResponse
                {
                    Success = true,
                    Response = "Transaction successful",

                };
            }
            catch (Exception x)
            {
                //req.CreateResponse(HttpStatusCode.InternalServerError);
                return new AjaxResponse
                {
                    Success = false,
                    Response = "Request Failed",
                    ExceptionMessage = x.ToString()
                };
            }
        }


    }
}
