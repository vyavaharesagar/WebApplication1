using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public String Login { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}