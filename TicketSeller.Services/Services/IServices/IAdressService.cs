using FluentResults;
using TicketSeller.Models.Dtos.AdressDto;

namespace TicketSeller.Services.Services.IServices;

public interface IAdressService
{
    ReadAdressDto AddAdress(CreateAdressDto createAdressDto);
    IEnumerable<ReadAdressDto> GetAdresses(int skip, int take);
    ReadAdressDto GetAdressById(int id);
    Result PutAdress(int id, UpdateAdressDto updadeAdressDto);
    Result DeleteAdress(int id);
}
