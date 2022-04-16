using Application.Features.Rentals.Commands.CreateRental;
using Application.Features.Rentals.Commands.DeleteRental;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Features.Rentals.Dtos;
using Application.Features.Rentals.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<Rental>, RentalListModel>().ReverseMap();
            CreateMap<Rental, RentalListDto>()
                .ForMember(dest => dest.CarModelBrandName, opt => opt.MapFrom(x => x.Car.Model.Brand.Name))
                .ForMember(dest => dest.CarModelName, opt => opt.MapFrom(x => x.Car.Model.Name))
                .ForMember(dest => dest.CarColorName, opt => opt.MapFrom(x => x.Car.Color.Name))
                .ForMember(dest => dest.CarModelYear, opt => opt.MapFrom(x => x.Car.ModelYear))
                .ForMember(dest => dest.CarPlate, opt => opt.MapFrom(x => x.Car.Plate))
                .ForMember(dest => dest.CustomerMail, opt => opt.MapFrom(x => x.Customer.Email)).ReverseMap();
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental, CreateRentalCommand>().ReverseMap();
            CreateMap<Rental, DeleteRentalDto>().ReverseMap();
            CreateMap<Rental, DeleteRentalCommand>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalCommand>().ReverseMap();
        }
    }
}
