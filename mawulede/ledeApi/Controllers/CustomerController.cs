using ledeHelpers;
using ledeModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mawulede_API.Controllers
{
    public class CustomerController : ApiController
    {

        DBHelper _helper;
        HttpRequestMessage req;

        public CustomerController()
        {
            _helper = new ledeHelpers.DBHelper();
        }
        public CustomerController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Customer> GetAllCustomers(int houseId)
        {
            var results = new List<Customer>();
            try
            {
                results = _helper.GetAllCustomers(houseId);
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
