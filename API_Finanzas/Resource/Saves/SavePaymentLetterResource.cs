using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Resource.Saves
{
    public class SavePaymentLetterResource
    {
        [Required]
        public string Currency { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime EmisisonDate { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}
