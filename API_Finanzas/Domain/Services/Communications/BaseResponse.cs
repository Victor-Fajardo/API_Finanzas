using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Succes { get; protected set; }
        public string Message { get; protected set; }
        public T Resource { get; set; }

        public BaseResponse(T resource)
        {
            Resource = resource;
            Succes = true;
            Message = string.Empty;
        }
        public BaseResponse(string message)
        {
            Succes = false;
            Message = message;
        }
    }
}
