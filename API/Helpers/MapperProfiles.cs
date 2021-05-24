using System.Linq;
using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {   
            CreateMap<Attachment, AttachmentToAdd>().ReverseMap();
            CreateMap<AccreditationPattern, AccreditationPatternToAdd>().ReverseMap();
            CreateMap<AppUser, UserToRegister>().ReverseMap();
            CreateMap<UserToReturn, AppUser>();
            CreateMap<AppUser, UserToReturn>()
                .ForMember(u => u.Role, opt => 
                    opt.MapFrom(src => src.UserRoles.FirstOrDefault(x => x.UserId==src.Id).Role.Name));
            CreateMap<Application, ApplicationToReturn>()
                .ForMember(m => m.NameOfUser, opt =>
                opt.MapFrom(src => src.User.Name))
                .ForMember(m => m.Surname, opt =>
                opt.MapFrom(src => src.User.Surname))
                .ForMember(m => m.Name, opt =>
                opt.MapFrom(src => src.Pattern.Name))
                .ForMember(m => m.Description, opt =>
                opt.MapFrom(src => src.Pattern.Description));

            CreateMap<ApplicationToAdd, Application>();
            CreateMap<UserAttachment, UserAttachmentToAdd>().ReverseMap();
            CreateMap<UserAttachment, UserAttachmentToReturn>();
            CreateMap<Attachment, AttachmentToReturn>();
            CreateMap<AccreditationToAdd, Accreditation>();
            CreateMap<Accreditation, AccreditationToReturn>()
                .ForMember(u => u.Name, opt =>
                opt.MapFrom(src => src.Pattern.Name))
                .ForMember(u => u.Description, opt =>
                opt.MapFrom(src => src.Pattern.Description))
                .ForMember(u => u.PatternId, opt =>
                opt.MapFrom(src => src.Pattern.Id))
                .ForMember(u => u.UserId, opt =>
                opt.MapFrom(src => src.User.Id))
                .ForMember(u => u.NameOfUser, opt =>
                opt.MapFrom(src => src.User.Name))
                .ForMember(u => u.Surname, opt =>
                opt.MapFrom(src => src.User.Surname));
        }
    }
}