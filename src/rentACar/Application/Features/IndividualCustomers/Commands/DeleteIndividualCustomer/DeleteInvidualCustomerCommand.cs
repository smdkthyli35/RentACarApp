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

namespace Application.Features.IndividualCustomers.Commands.DeleteIndividualCustomer
{
    public class DeleteIndividualCustomerCommand : IRequest<DeleteIndividualCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeleteIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<DeleteIndividualCustomerDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var invidualCustomerToBeDeleted = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (invidualCustomerToBeDeleted is null)
                    throw new BusinessException("Böyle bir bireysel müşteri bulunamadı.");

                IndividualCustomer mappedInvidualCustomer = _mapper.Map<IndividualCustomer>(request);
                var deletedInvidualCustomer = _individualCustomerRepository.DeleteAsync(mappedInvidualCustomer);
                DeleteIndividualCustomerDto deleteInvidualCustomerDto = _mapper.Map<DeleteIndividualCustomerDto>(deletedInvidualCustomer);
                return deleteInvidualCustomerDto;
            }
        }
    }
}
