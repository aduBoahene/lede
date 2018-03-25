using System;
using System.Collections.Generic;
using System.Text;

namespace ledeModels.Model
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public String PromotionName { get; set; }
        public String Description { get; set; }
        public int HouseId { get; set; }
    }
}
