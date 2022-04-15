using Application.Features.CarDamages.Commands.CreateCarDamage;
using Application.Features.CarDamages.Commands.DeleteCarDamage;
using Application.Features.CarDamages.Commands.UpdateCarDamage;
using Application.Features.CarDamages.Dtos;
using Application.Features.CarDamages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<CarDamage>, CarDamageListModel>().ReverseMap();
            CreateMap<CarDamage, CreateCarDamageDto>().ReverseMap();
            CreateMap<CarDamage, CreateCarDamageCommand>().ReverseMap();
            CreateMap<CarDamage, DeleteCarDamageDto>().ReverseMap();
            CreateMap<CarDamage, DeleteCarDamageCommand>().ReverseMap();
            CreateMap<CarDamage, UpdateCarDamageDto>().ReverseMap();
            CreateMap<CarDamage, UpdateCarDamageCommand>().ReverseMap();
            CreateMap<CarDamage, CarDamageListDto>()
                .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(x => x.Car.Model.Name))
                .ForMember(dest => dest.CarModelBrandName, opt => opt.MapFrom(x => x.Car.Model.Brand.Name))
                .ForMember(dest => dest.CarModelBrandName, opt => opt.MapFrom(x => x.Car.Model.Brand.Name))
                .ForMember(dest => dest.CarModelYear, opt => opt.MapFrom(x => x.Car.ModelYear))
                .ForMember(dest => dest.CarPlate, opt => opt.MapFrom(x => x.Car.Plate)).ReverseMap();
        }
    }
}
