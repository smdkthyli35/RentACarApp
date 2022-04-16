using Application.Features.Invoices.Commands.CreateInvoice;
using Application.Features.Invoices.Commands.DeleteInvoice;
using Application.Features.Invoices.Commands.UpdateInvoice;
using Application.Features.Invoices.Dtos;
using Application.Features.Invoices.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<Invoice>, InvoiceListModel>().ReverseMap();
            CreateMap<Invoice, InvoiceListDto>().ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(x => x.Customer.Email)).ReverseMap();
            CreateMap<Invoice, CreateInvoiceDto>().ReverseMap();
            CreateMap<Invoice, CreateInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceDto>().ReverseMap();
            CreateMap<Invoice, DeleteInvoiceCommand>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceDto>().ReverseMap();
            CreateMap<Invoice, UpdateInvoiceCommand>().ReverseMap();
        }
    }
}
