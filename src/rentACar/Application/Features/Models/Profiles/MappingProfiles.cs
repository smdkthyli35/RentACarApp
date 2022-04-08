using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Commands.DeleteModel;
using Application.Features.Models.Commands.UpdateModel;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelDto>();
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, DeleteModelDto>();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelDto>();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, ModelListDto>()
                .ForMember(dest => dest.TransmissionName, opt => opt.MapFrom(m => m.Transmission.Name))
                .ForMember(dest => dest.FuelName, opt => opt.MapFrom(m => m.Fuel.Name))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(m => m.Brand.Name));
            CreateMap<IPaginate<Model>, ModelListModel>();
        }
    }
}
