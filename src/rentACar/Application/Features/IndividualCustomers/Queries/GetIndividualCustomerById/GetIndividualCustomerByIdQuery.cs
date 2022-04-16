using Application.Features.Brands.Dtos;
using Application.Features.IndividualCustomers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Queries.GetIndividualCustomerById
{
    public class GetIndividualCustomerByIdQuery : IRequest<IndividualCustomerDto>
    {
        public int Id { get; set; }

        public class GetIndividualCustomerByIdQueryHandler : IRequestHandler<GetIndividualCustomerByIdQuery, IndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetIndividualCustomerByIdQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<IndividualCustomerDto> Handle(GetIndividualCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var individualCustomerIsTheExists = await _individualCustomerRepository.GetAsync(b => b.Id == request.Id);
                if (individualCustomerIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir bireysel müşteri bilgisi bulunamadı!");
                else
                {
                    IndividualCustomerDto individualCustomerDto = _mapper.Map<IndividualCustomerDto>(individualCustomerIsTheExists);
                    return individualCustomerDto;
                }
            }
        }
    }
}
