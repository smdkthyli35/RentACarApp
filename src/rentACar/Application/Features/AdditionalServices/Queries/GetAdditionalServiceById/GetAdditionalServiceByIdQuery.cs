using Application.Features.AdditionalServices.Dtos;
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

namespace Application.Features.AdditionalServices.Queries.GetAdditionalServiceById
{
    public class GetAdditionalServiceByIdQuery : IRequest<AdditionalServiceDto>
    {
        public int Id { get; set; }

        public class GetAdditionalServiceByIdQueryHandler : IRequestHandler<GetAdditionalServiceByIdQuery, AdditionalServiceDto>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public GetAdditionalServiceByIdQueryHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<AdditionalServiceDto> Handle(GetAdditionalServiceByIdQuery request, CancellationToken cancellationToken)
            {
                var additionalServiceIsTheExists = await _additionalServiceRepository.GetAsync(a => a.Id == request.Id);
                if (additionalServiceIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir ek hizmet bulunamadı!");
                else
                {
                    AdditionalServiceDto additionalServiceDto = _mapper.Map<AdditionalServiceDto>(additionalServiceIsTheExists);
                    return additionalServiceDto;
                }
            }
        }
    }
}
