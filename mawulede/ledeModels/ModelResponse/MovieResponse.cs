using ledeModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ledeModels.ModelResponse
{
    public class MovieResponse:AjaxResponse
    {
        public List<Movie> data { get; set; }
    }
}
