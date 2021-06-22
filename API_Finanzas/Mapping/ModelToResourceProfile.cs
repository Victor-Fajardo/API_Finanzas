using API_Finanzas.Domain.Models;
using API_Finanzas.Resource;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Operation, OperationResource>();
            CreateMap<PaymentLetter, PaymentLetterResource>();
            CreateMap<User, UserResource>();
        }
    }
}
