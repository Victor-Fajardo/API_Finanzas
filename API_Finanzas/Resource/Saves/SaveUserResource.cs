using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Resource.Saves
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        [Required]
        public int RUC { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
