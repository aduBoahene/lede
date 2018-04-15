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

namespace ledeApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]

    public class GenreController : ApiController
    {

        DBHelper _helper;
        HttpRequestMessage req;

        public GenreController()
        {
            _helper = new ledeHelpers.DBHelper();
        }
        public GenreController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Genre> GetAllGenre()
        {
            var results = new List<Genre>();
            try
            {
                results = _helper.GetAllGenre();
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
    }
}
