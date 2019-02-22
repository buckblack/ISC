using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codefirst.Models.respone
{
    public class LoginRespone
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
