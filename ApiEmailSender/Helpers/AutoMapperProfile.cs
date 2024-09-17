using ApiEmailSender.Application.Email.Query;
using ApiEmailSender.Domain;
using AutoMapper;

namespace ApiEmailSender.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmailSend, EmailSenderResult>().ReverseMap();
        }
    }
}
