using ledeHelpers;
using ledeModels.Model;
using ledeModels.ModelResponse;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace Mawulede_API.Controllers
{
    public class BookingController : ApiController
    {
        DBHelper _helper;
        HttpRequestMessage req;

        public BookingController()
        {
            _helper = new ledeHelpers.DBHelper();
        }
        public BookingController(DBHelper helper)
        {
            _helper = helper;
        }

        [HttpGet]
        public List<Booking> GetAllBooking(int houseId)
        {
            var results = new List<Booking>();
            try
            {
                results = _helper.GetAllBooking(houseId);
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
        public AjaxResponse SubmitBooking([FromBody]PostBooking newBooking)
        {
            try
            {
                int prod;
                var httpRequest = HttpContext.Current.Request;
                if (!string.IsNullOrEmpty(newBooking.BookingNumber))
                {
                    prod = _helper.PostBooking(newBooking);
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
