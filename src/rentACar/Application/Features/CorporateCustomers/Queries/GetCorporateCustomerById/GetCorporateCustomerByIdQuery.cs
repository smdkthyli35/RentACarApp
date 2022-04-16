using Application.Features.Brands.Dtos;
using Application.Features.CorporateCustomers.Dtos;
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

namespace Application.Features.CorporateCustomers.Queries.GetCorporateCustomerById
{
    public class GetCorporateCustomerByIdQuery : IRequest<CorporateCustomerDto>
    {
        public int Id { get; set; }

        public class GetCorporateCustomerByIdQueryHandler : IRequestHandler<GetCorporateCustomerByIdQuery, CorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetCorporateCustomerByIdQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<CorporateCustomerDto> Handle(GetCorporateCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                var corporateCustomerIsTheExists = await _corporateCustomerRepository.GetAsync(b => b.Id == request.Id);
                if (corporateCustomerIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir kurumsal müşteri bilgisi bulunamadı!");
                else
                {
                    CorporateCustomerDto corporateCustomerDto = _mapper.Map<CorporateCustomerDto>(corporateCustomerIsTheExists);
                    return corporateCustomerDto;
                }
            }
        }
    }
}
