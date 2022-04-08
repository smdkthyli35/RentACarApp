using Application.Features.Models.Dtos;
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

namespace Application.Features.Models.Commands.UpdateModel
{
    public class UpdateModelCommand : IRequest<UpdateModelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }

        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdateModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<UpdateModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                var modelToBeUpdated = await _modelRepository.GetAsync(m => m.Id == request.Id);
                if (modelToBeUpdated is null)
                    throw new BusinessException("Böyle bir model bulunamadı!");

                Model mappedModel = _mapper.Map<Model>(request);
                var updatedModel = _modelRepository.UpdateAsync(mappedModel);
                UpdateModelDto updateModelDto = _mapper.Map<UpdateModelDto>(updatedModel);
                return updateModelDto;
            }
        }
    }
}
