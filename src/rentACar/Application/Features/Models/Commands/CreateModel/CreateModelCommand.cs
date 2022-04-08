using Application.Features.Models.Dtos;
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

namespace Application.Features.Models.Commands.CreateModel
{
    public class CreateModelCommand : IRequest<CreateModelDto>
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

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<CreateModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                Model mappedModel = _mapper.Map<Model>(request);
                Model createdModel = await _modelRepository.AddAsync(mappedModel);
                CreateModelDto createModelDto = _mapper.Map<CreateModelDto>(createdModel);
                return createModelDto;
            }
        }
    }
}
