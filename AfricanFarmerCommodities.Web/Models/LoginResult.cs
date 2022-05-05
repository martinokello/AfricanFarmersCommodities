using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfricanFarmerCommodities.Web.Models
{
    public class LoginResult
    {
        public bool IsLoggedIn { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsRegistered { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public string AuthToken { get; set; }
    }
}
