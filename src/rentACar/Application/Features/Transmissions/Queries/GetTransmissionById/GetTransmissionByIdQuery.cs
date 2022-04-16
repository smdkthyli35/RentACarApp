using Application.Features.Brands.Dtos;
using Application.Features.Transmissions.Dtos;
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

namespace Application.Features.Transmissions.Queries.GetTransmissionById
{
    public class GetTransmissionByIdQuery : IRequest<TransmissionDto>
    {
        public int Id { get; set; }

        public class GetTransmissionByIdQueryHandler : IRequestHandler<GetTransmissionByIdQuery, TransmissionDto>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public GetTransmissionByIdQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<TransmissionDto> Handle(GetTransmissionByIdQuery request, CancellationToken cancellationToken)
            {
                var transmissionIsTheExists = await _transmissionRepository.GetAsync(b => b.Id == request.Id);
                if (transmissionIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir vites bilgisi bulunamadı!");
                else
                {
                    TransmissionDto transmissionDto = _mapper.Map<TransmissionDto>(transmissionIsTheExists);
                    return transmissionDto;
                }
            }
        }
    }
}
