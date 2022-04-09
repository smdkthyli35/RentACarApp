using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Commands.DeleteTransmission;
using Application.Features.Transmissions.Commands.UpdateTransmission;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Transmission, TransmissionListDto>().ReverseMap();
            CreateMap<Transmission, CreateTransmissionDto>().ReverseMap();
            CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, DeleteTransmissionDto>().ReverseMap();
            CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
            CreateMap<Transmission, UpdateTransmissionDto>().ReverseMap();
            CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
            CreateMap<IPaginate<Transmission>, TransmissionListModel>().ReverseMap();
        }
    }
}
