using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmlakPortali.Dtos;
using EmlakPortali.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmlakPortali.Controllers
{
    [Route("api/House")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public HouseController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Dtos.HouseDto> GetList()
        {
            var house = _context.House.ToList();
            var houseDtos = _mapper.Map<List<Dtos.HouseDto>>(house);
            return houseDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public Dtos.HouseDto Get(int id)
        {
            var house = _context.House.Where(s => s.Id == id).SingleOrDefault();
            var houseDto = _mapper.Map<Dtos.HouseDto>(house);
            return houseDto;
        }

        [HttpPost]
        public ResultDto Post(Dtos.HouseDto dto)
        {
            if (_context.House.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Ev İlanı Kayıtlıdır!";
                return result;
            }
            var house = _mapper.Map<House>(dto);
            house.Updated = DateTime.Now;
            house.Created = DateTime.Now;
            _context.House.Add(house);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ev İlanı Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(Dtos.HouseDto dto)
        {
            var house = _context.House.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (house == null)
            {
                result.Status = false;
                result.Message = "Ev İlanı Bulunamadı!";
                return result;
            }
            house.Name = dto.Name;
            house.IsActive = dto.IsActive;
            house.Price = dto.Price;
            house.Updated = DateTime.Now;
            house.CategoryId = dto.CategoryId;
            _context.House.Update(house);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ev İlanı Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var house = _context.House.Where(s => s.Id == id).SingleOrDefault();
            if (house == null)
            {
                result.Status = false;
                result.Message = "Ev İlanı Bulunamadı!";
                return result;
            }
            _context.House.Remove(house);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ev İlanı Silindi";
            return result;
        }
    }
}
