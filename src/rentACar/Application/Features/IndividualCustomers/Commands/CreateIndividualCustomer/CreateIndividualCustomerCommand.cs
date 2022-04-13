using Application.Features.IndividualCustomers.Dtos;
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

namespace Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer
{
    public class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerDto>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class CreateInvidualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public CreateInvidualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CreateIndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                IndividualCustomer mappedInvidualCustomer = _mapper.Map<IndividualCustomer>(request);
                IndividualCustomer createdInvidualCustomer = await _individualCustomerRepository.AddAsync(mappedInvidualCustomer);
                CreateIndividualCustomerDto createInvidualCustomerDto = _mapper.Map<CreateIndividualCustomerDto>(createdInvidualCustomer);
                return createInvidualCustomerDto;
            }
        }
    }
}
