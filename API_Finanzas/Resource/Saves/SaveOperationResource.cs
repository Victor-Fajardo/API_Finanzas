using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Resource.Saves
{
    public class SaveOperationResource
    {
        [Required]
        public float Rate { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public float NetValue { get; set; }
        [Required]
        public float OutputValue { get; set; }
        [Required]
        public float Flow { get; set; }
        [Required]
        public float TCEA { get; set; }
    }
}
