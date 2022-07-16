using AutoMapper;

namespace EmpApi.Persistence.Helper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
    {
        CreateMap<AddessDto, AddressModel>();
        CreateMap<AddressModel, AddessDto>();
        CreateMap<PersonDto, PersonModel>();
        CreateMap<PersonModel, PersonDto>();
    }
}
}
