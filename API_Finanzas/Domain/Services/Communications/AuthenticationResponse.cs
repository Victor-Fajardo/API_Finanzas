using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services.Communications
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public int RUC { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            UserId = user.UserId;
            UserName = user.UserName;
            CompanyName = user.CompanyName;
            RUC = user.RUC;
            Email = user.Email;
            Token = token;
        }
    }
}
