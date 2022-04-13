using Application.Features.IndividualCustomers.Dtos;
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

namespace Application.Features.IndividualCustomers.Commands.UpdateIndividualCustomer
{
    public class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirtName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<UpdateIndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var invidualCustomerToBeUpdated = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (invidualCustomerToBeUpdated is null)
                    throw new BusinessException("Böyle bir bireysel müşteri bulunamadı.");

                IndividualCustomer mappedInvidualCustomer = _mapper.Map<IndividualCustomer>(request);
                var updatedInvidualCustomer = _individualCustomerRepository.UpdateAsync(mappedInvidualCustomer);
                UpdateIndividualCustomerDto updateInvidualCustomerDto = _mapper.Map<UpdateIndividualCustomerDto>(updatedInvidualCustomer);
                return updateInvidualCustomerDto;
            }
        }
    }
}
