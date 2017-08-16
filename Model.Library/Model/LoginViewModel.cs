using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webservice.api.Model
{
    public class LoginViewModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public User result { get; set; }
    }
}