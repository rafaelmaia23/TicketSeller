using AutoMapper;
using FluentResults;
using TicketSeller.DAL.Repository.IRepository;
using TicketSeller.Models.Dtos.AdressDto;
using TicketSeller.Models.Models;
using TicketSeller.Services.Services.IServices;

namespace TicketSeller.Services.Services;

public class AdressService : IAdressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AdressService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public ReadAdressDto AddAdress(CreateAdressDto createAdressDto)
    {
        Adress adress = _mapper.Map<Adress>(createAdressDto);
        _unitOfWork.Adress.Add(adress);
        _unitOfWork.Save();
        return _mapper.Map<ReadAdressDto>(adress);
    }
    public IEnumerable<ReadAdressDto> GetAdresses()
    {
        IEnumerable<Adress> adresses = _unitOfWork.Adress.GetAll();
        IEnumerable<ReadAdressDto> readAdressDtos = _mapper.Map<List<ReadAdressDto>>(adresses);
        return readAdressDtos;
    }
    public ReadAdressDto GetAdressById(int id)
    {
        Adress adress = _unitOfWork.Adress.GetById(x => x.Id == id);
        if (adress != null)
        {
            ReadAdressDto readAdressDto = _mapper.Map<ReadAdressDto>(adress);
            return readAdressDto;
        }
        return null;
    }

    public Result PutAdress(int id, UpdateAdressDto updadeAdressDto)
    {
        Adress adress = _unitOfWork.Adress.GetById(x => x.Id == id);
        if (adress == null) return Result.Fail("Adress Not Found");
        _mapper.Map(updadeAdressDto, adress);
        _unitOfWork.Save();
        return Result.Ok();
    }

    public Result DeleteAdress(int id)
    {
        Adress adress = _unitOfWork.Adress.GetById(x => x.Id == id);
        if (adress == null) return null;
        if (adress.Cinema != null) return Result.Fail("Cannot delete a Adress that contain a Cinema");
        _unitOfWork.Adress.Remove(adress);
        _unitOfWork.Save();
        return Result.Ok();
    }
}
