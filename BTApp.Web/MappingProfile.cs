using AutoMapper;
using BTApp.Entities;
using BTApp.Web.Models;

namespace BTApp.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserPassword, UserPasswordDTO>();
            CreateMap<UserPasswordDTO, UserPassword>();
        }
    }
}
