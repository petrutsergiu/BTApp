using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BTApp.Entities
{
    public class UserPassword
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public DateTime ValideFrom { get; set; }
        public DateTime ValideTo { get; set; }

    }
}
