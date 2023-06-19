using API.Dtos;
using API.Extentions;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
	public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(desc => desc.PhotoUrl, opt => opt.MapFrom(p => p.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
			CreateMap<Photo, PhotoDto>();
        }
    }
}
