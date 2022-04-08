using Application.Features.Cars.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CreateCarDto>().ReverseMap();
            CreateMap<Car, DeleteCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
        }
    }
}
