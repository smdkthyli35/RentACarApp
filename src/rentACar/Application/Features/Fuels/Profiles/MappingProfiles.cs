﻿using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Fuel, FuelListDto>().ReverseMap();
            CreateMap<Fuel, CreateFuelDto>().ReverseMap();
            CreateMap<Fuel, DeleteFuelDto>().ReverseMap();
            CreateMap<Fuel, UpdateFuelDto>().ReverseMap();
            CreateMap<IPaginate<Fuel>, FuelListModel>().ReverseMap();
        }
    }
}
