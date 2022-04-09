﻿using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Color, ColorListDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();
            CreateMap<Color, DeleteColorDto>().ReverseMap();
            CreateMap<Color, UpdateColorDto>().ReverseMap();
            CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();
        }
    }
}
