using AutoMapper;
using ParallexTask1.Dto;
using ParallexTask1.Entities;

namespace ParallexTask1
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<UserForRegistrationDto, User>();

        }
    }
}
