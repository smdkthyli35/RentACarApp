using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.CreateCorporateCustomer
{
    public class CreateCorporateCustomerCommand : IRequest<CreateCorporateCustomerDto>
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreateCorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CreateCorporateCustomerDto> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                CorporateCustomer createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
                CreateCorporateCustomerDto createCorporateCustomerDto = _mapper.Map<CreateCorporateCustomerDto>(createdCorporateCustomer);
                return createCorporateCustomerDto;
            }
        }
    }
}
