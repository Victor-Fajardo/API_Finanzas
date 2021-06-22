using API_Finanzas.Domain.Models;
using API_Finanzas.Resource.Saves;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveOperationResource, Operation>();
            CreateMap<SavePaymentLetterResource, PaymentLetter>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
