using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Resource
{
    public class OperationResource
    {
        public int OperationId { get; set; }
        public float Rate { get; set; }
        public float Discount { get; set; }
        public float NetValue { get; set; }
        public float OutputValue { get; set; }
        public float Flow { get; set; }
        public float TCEA { get; set; }
    }
}
