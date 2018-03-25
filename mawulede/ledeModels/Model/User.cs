using System;
using System.Collections.Generic;
using System.Text;

namespace ledeModels.Model
{
    public class User
    {
        public int UserId { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public DateTime LastLogon { get; set; }
        public int passwordAttemptCount { get; set; }
        public int HouseId { get; set; }

    }
}
