using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTApp.Web.Models
{
    public class UserPasswordDTO
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public DateTime ValideFrom { get; set; }
        public string IsValid { get; set; }
    }
}
