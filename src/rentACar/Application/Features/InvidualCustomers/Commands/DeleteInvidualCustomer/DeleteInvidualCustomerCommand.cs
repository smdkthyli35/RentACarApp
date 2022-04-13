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

namespace Application.Features.InvidualCustomers.Commands.DeleteInvidualCustomer
{
    public class DeleteInvidualCustomerCommand : IRequest<DeleteInvidualCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteInvidualCustomerCommandHandler : IRequestHandler<DeleteInvidualCustomerCommand, DeleteInvidualCustomerDto>
        {
            private readonly IInvidualCustomerRepository _invidualCustomerRepository;
            private readonly IMapper _mapper;

            public DeleteInvidualCustomerCommandHandler(IInvidualCustomerRepository invidualCustomerRepository, IMapper mapper)
            {
                _invidualCustomerRepository = invidualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<DeleteInvidualCustomerDto> Handle(DeleteInvidualCustomerCommand request, CancellationToken cancellationToken)
            {
                var invidualCustomerToBeDeleted = await _invidualCustomerRepository.GetAsync(i => i.Id == request.Id);
                if (invidualCustomerToBeDeleted is null)
                    throw new BusinessException("Böyle bir bireysel müşteri bulunamadı.");

                InvidualCustomer mappedInvidualCustomer = _mapper.Map<InvidualCustomer>(request);
                var deletedInvidualCustomer = _invidualCustomerRepository.DeleteAsync(mappedInvidualCustomer);
                DeleteInvidualCustomerDto deleteInvidualCustomerDto = _mapper.Map<DeleteInvidualCustomerDto>(deletedInvidualCustomer);
                return deleteInvidualCustomerDto;
            }
        }
    }
}
