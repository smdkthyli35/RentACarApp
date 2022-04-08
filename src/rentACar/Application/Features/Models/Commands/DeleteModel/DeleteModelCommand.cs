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

namespace Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand : IRequest<DeleteModelDto>
    {
        public int Id { get; set; }

        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<DeleteModelDto> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var modelToBeDeleted = await _modelRepository.GetAsync(m => m.Id == request.Id);
                if (modelToBeDeleted is null)
                    throw new BusinessException("Böyle bir model bulumamadı!");

                Model mappedModel = _mapper.Map<Model>(request);
                var deletedModel = _modelRepository.DeleteAsync(mappedModel);
                DeleteModelDto deleteModelDto = _mapper.Map<DeleteModelDto>(deletedModel);
                return deleteModelDto;
            }
        }
    }
}
