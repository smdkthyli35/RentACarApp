using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommand : IRequest<UpdateCorporateCustomerDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdateCorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<UpdateCorporateCustomerDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var corporateCustomerToBeUpdated = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (corporateCustomerToBeUpdated is null)
                    throw new BusinessException("Böyle bir kurumsal müşteri bulunamadı.");

                CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                var updatedCorporateCustomer = _corporateCustomerRepository.UpdateAsync(mappedCorporateCustomer);
                UpdateCorporateCustomerDto updateCorporateCustomerDto = _mapper.Map<UpdateCorporateCustomerDto>(updatedCorporateCustomer);
                return updateCorporateCustomerDto;
            }
        }
    }
}
