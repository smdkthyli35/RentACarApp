using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
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

namespace Application.Features.Models.Commands.CreateModel
{
    public class CreateModelCommand : IRequest<CreateModelDto>, ILoggableRequest
    {
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;
            private readonly ModelBusinessRules _modelBusinessRules;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<CreateModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                await _modelBusinessRules.ModelNameCanNotBeDuplicatedWhenInserted(request.Name);

                Model mappedModel = _mapper.Map<Model>(request);
                Model createdModel = await _modelRepository.AddAsync(mappedModel);
                CreateModelDto createModelDto = _mapper.Map<CreateModelDto>(createdModel);
                return createModelDto;
            }
        }
    }
}
