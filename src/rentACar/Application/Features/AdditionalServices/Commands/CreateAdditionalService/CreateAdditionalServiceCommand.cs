using Application.Features.AdditionalServices.Dtos;
using Application.Features.AdditionalServices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
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
    public class CreateAdditionalServiceCommand : IRequest<CreateAdditionalServiceDto>, ILoggableRequest
    {
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }

        public class CreateAdditionalServiceCommandHandler : IRequestHandler<CreateAdditionalServiceCommand, CreateAdditionalServiceDto>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;
            private readonly AdditionalServiceBusinessRules _additionalServiceBusinessRules;

            public CreateAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper, AdditionalServiceBusinessRules additionalServiceBusinessRules)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
                _additionalServiceBusinessRules = additionalServiceBusinessRules;
            }

            public async Task<CreateAdditionalServiceDto> Handle(CreateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                await _additionalServiceBusinessRules.AdditionalServiceNameCanNotBeDuplicatedWhenInserted(request.Name);

                AdditionalService mappedAdditionalService = _mapper.Map<AdditionalService>(request);
                AdditionalService createdAdditionalService = await _additionalServiceRepository.AddAsync(mappedAdditionalService);
                CreateAdditionalServiceDto createAdditionalServiceDto = _mapper.Map<CreateAdditionalServiceDto>(createdAdditionalService);
                return createAdditionalServiceDto;
            }
        }
    }
}
