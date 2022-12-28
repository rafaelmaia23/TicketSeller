using AutoMapper;
using TicketSeller.Models.Dtos.AdressDto;
using TicketSeller.Models.Models;

namespace TicketSeller.API.Profiles;

public class AdressProfile : Profile
{
    public AdressProfile()
    {
        CreateMap<Adress, ReadAdressDto>();
        CreateMap<CreateAdressDto, Adress>();
        CreateMap<UpdateAdressDto, Adress>();
    }
}
