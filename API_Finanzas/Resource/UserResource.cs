using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Resource
{
    public class UserResource
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string CompanyName { get; set; }
        public int RUC { get; set; }
        public string Email { get; set; }
    }
}
