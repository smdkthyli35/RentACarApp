using Application.Features.InvidualCustomers.Dtos;
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

namespace Application.Features.InvidualCustomers.Commands.UpdateInvidualCustomer
{
    public class UpdateInvidualCustomerCommand : IRequest<UpdateInvidualCustomerDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class UpdateInvidualCustomerCommandHandler : IRequestHandler<UpdateInvidualCustomerCommand, UpdateInvidualCustomerDto>
        {
            private readonly IInvidualCustomerRepository _invidualCustomerRepository;
            private readonly IMapper _mapper;

            public UpdateInvidualCustomerCommandHandler(IInvidualCustomerRepository invidualCustomerRepository, IMapper mapper)
            {
                _invidualCustomerRepository = invidualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<UpdateInvidualCustomerDto> Handle(UpdateInvidualCustomerCommand request, CancellationToken cancellationToken)
            {
                var invidualCustomerToBeUpdated = await _invidualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (invidualCustomerToBeUpdated is null)
                    throw new BusinessException("Böyle bir bireysel müşteri bulunamadı.");

                InvidualCustomer mappedInvidualCustomer = _mapper.Map<InvidualCustomer>(request);
                var updatedInvidualCustomer = _invidualCustomerRepository.UpdateAsync(mappedInvidualCustomer);
                UpdateInvidualCustomerDto updateInvidualCustomerDto = _mapper.Map<UpdateInvidualCustomerDto>(updatedInvidualCustomer);
                return updateInvidualCustomerDto;
            }
        }
    }
}
