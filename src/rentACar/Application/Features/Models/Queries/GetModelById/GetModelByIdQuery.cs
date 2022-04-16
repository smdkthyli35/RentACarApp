using Application.Features.Brands.Dtos;
using Application.Features.Models.Dtos;
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

namespace Application.Features.Models.Queries.GetModelById
{
    public class GetModelByIdQuery : IRequest<ModelDto>
    {
        public int Id { get; set; }

        public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, ModelDto>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetModelByIdQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelDto> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
            {
                var modelIsTheExists = await _modelRepository.GetAsync(b => b.Id == request.Id);
                if (modelIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir model bulunamadı!");
                else
                {
                    ModelDto modelDto = _mapper.Map<ModelDto>(modelIsTheExists);
                    return modelDto;
                }
            }
        }
    }
}
