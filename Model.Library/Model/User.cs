using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice.api.Model
{
    public class User
    {
        public long User_code { get; set; }
        public decimal Mobile { get; set; }
        public string Mail { get; set; }
    }
}