using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetModelList
{
    public class GetModelListQuery : IRequest<ModelListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => "models-list";

        public TimeSpan? SlidingExpiration { get; set; }

        public class GetModelListQueryHandler : IRequestHandler<GetModelListQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetModelListQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetModelListQuery request, CancellationToken cancellationToken)
            {
                var models = await _modelRepository.GetListAsync(
                    null,
                    include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
