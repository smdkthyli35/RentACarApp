using Application.Features.InvidualCustomers.Commands.CreateInvidualCustomer;
using Application.Features.InvidualCustomers.Commands.DeleteInvidualCustomer;
using Application.Features.InvidualCustomers.Commands.UpdateInvidualCustomer;
using Application.Features.InvidualCustomers.Dtos;
using Application.Features.InvidualCustomers.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvidualCustomers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<InvidualCustomer, InvidualCustomerListDto>().ReverseMap();
            CreateMap<IPaginate<InvidualCustomer>, InvidualCustomerListModel>().ReverseMap();
            CreateMap<InvidualCustomer, CreateInvidualCustomerDto>().ReverseMap();
            CreateMap<InvidualCustomer, CreateInvidualCustomerCommand>().ReverseMap();
            CreateMap<InvidualCustomer, DeleteInvidualCustomerDto>().ReverseMap();
            CreateMap<InvidualCustomer, DeleteInvidualCustomerCommand>().ReverseMap();
            CreateMap<InvidualCustomer, UpdateInvidualCustomerDto>().ReverseMap();
            CreateMap<InvidualCustomer, UpdateInvidualCustomerCommand>().ReverseMap();
        }
    }
}
