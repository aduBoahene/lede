using System;
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
    public class PromotionsController : ApiController
    {
        DBHelper _helper;
        HttpRequestMessage req;

        public PromotionsController()
        {
            _helper = new ledeHelpers.DBHelper();
        }
        public PromotionsController(DBHelper helper)
        {
            _helper = helper;
        }


        [HttpGet]
        public List<Promotion> GetAllPromotions(int houseId)
        {
            var results = new List<Promotion>();
            try
            {
                results = _helper.GetAllPromotions(houseId);
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
