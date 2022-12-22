using FluentResults;
using TicketSeller.Models.Dto.AdressDto;

namespace TicketSeller.Services.Services.IServices;

public interface IAdressService
{
    ReadAdressDto AddAdress(CreateAdressDto createAdressDto);
    IEnumerable<ReadAdressDto> GetAdresses();
    ReadAdressDto GetAdressById(int id);
    Result PutAdress(int id, UpdateAdressDto updadeAdressDto);
    Result DeleteAdress(int id);
}
