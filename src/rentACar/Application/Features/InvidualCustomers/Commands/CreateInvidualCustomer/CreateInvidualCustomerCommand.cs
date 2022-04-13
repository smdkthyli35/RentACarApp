using Application.Features.InvidualCustomers.Dtos;
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

namespace Application.Features.InvidualCustomers.Commands.CreateInvidualCustomer
{
    public class CreateInvidualCustomerCommand : IRequest<CreateInvidualCustomerDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class CreateInvidualCustomerCommandHandler : IRequestHandler<CreateInvidualCustomerCommand, CreateInvidualCustomerDto>
        {
            private readonly IInvidualCustomerRepository _invidualCustomerRepository;
            private readonly IMapper _mapper;

            public CreateInvidualCustomerCommandHandler(IInvidualCustomerRepository invidualCustomerRepository, IMapper mapper)
            {
                _invidualCustomerRepository = invidualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CreateInvidualCustomerDto> Handle(CreateInvidualCustomerCommand request, CancellationToken cancellationToken)
            {
                InvidualCustomer mappedInvidualCustomer = _mapper.Map<InvidualCustomer>(request);
                InvidualCustomer createdInvidualCustomer = await _invidualCustomerRepository.AddAsync(mappedInvidualCustomer);
                CreateInvidualCustomerDto createInvidualCustomerDto = _mapper.Map<CreateInvidualCustomerDto>(createdInvidualCustomer);
                return createInvidualCustomerDto;
            }
        }
    }
}
