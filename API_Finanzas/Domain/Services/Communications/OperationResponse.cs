using API_Finanzas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services.Communications
{
    public class OperationResponse : BaseResponse<Operation>
    {
        public OperationResponse(Operation resource) : base(resource)
        {
        }

        public OperationResponse(string message) : base(message)
        {
        }
    }
}
