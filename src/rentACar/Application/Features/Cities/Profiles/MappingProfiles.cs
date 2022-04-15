using Application.Features.Cities.Commands.CreateCity;
using Application.Features.Cities.Commands.DeleteCity;
using Application.Features.Cities.Commands.UpdateCity;
using Application.Features.Cities.Dtos;
using Application.Features.Cities.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityListDto>().ReverseMap();
            CreateMap<IPaginate<City>, CityListModel>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, CreateCityCommand>().ReverseMap();
            CreateMap<City, DeleteCityDto>().ReverseMap();
            CreateMap<City, DeleteCityCommand>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();
        }
    }
}
