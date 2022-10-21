using AutoMapper;
using Core.Models;
using EmailSender.Core.DTO;

namespace EmailSender.Core.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
