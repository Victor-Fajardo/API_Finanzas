using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
        public string CompanyName { get; set; }
        public int RUC { get; set; }
        public string Email { get; set; }
        public bool Connected { get; set; }
        public List<PaymentLetter> PaymentLetters { get; set; }
    }
}
