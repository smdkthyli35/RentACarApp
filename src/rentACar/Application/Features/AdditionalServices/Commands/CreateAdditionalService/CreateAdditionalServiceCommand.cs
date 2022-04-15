using Application.Features.AdditionalServices.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AdditionalServices.Commands.CreateAdditionalService
{
    public class CreateAdditionalServiceCommand : IRequest<CreateAdditionalServiceDto>
    {
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }

        public class CreateAdditionalServiceCommandHandler : IRequestHandler<CreateAdditionalServiceCommand, CreateAdditionalServiceDto>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public CreateAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<CreateAdditionalServiceDto> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                AdditionalService mappedAdditionalService = _mapper.Map<AdditionalService>(request);
                AdditionalService createdAdditionalService = await _additionalServiceRepository.AddAsync(mappedAdditionalService);
                CreateAdditionalServiceDto createAdditionalServiceDto = _mapper.Map<CreateAdditionalServiceDto>(createdAdditionalService);
                return createAdditionalServiceDto;
            }
        }
    }
}
