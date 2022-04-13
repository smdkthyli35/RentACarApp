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

namespace Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer
{
    public class DeleteCorporateCustomerCommand : IRequest<DeleteCorporateCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeleteCorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<DeleteCorporateCustomerDto> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var corporateCustomerToBeDeleted = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (corporateCustomerToBeDeleted is null)
                    throw new BusinessException("Böyle bir kurumsal müşteri bulunamadı.");

                CorporateCustomer mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                var deletedCorporateCustomer = _corporateCustomerRepository.DeleteAsync(mappedCorporateCustomer);
                DeleteCorporateCustomerDto deleteCorporateCustomerDto = _mapper.Map<DeleteCorporateCustomerDto>(deletedCorporateCustomer);
                return deleteCorporateCustomerDto;
            }
        }
    }
}
