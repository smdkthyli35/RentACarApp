using Application.Features.Colors.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Colors.Queries.GetColorList
{
    public class GetColorListQuery : IRequest<ColorListModel>, ICachableRequest
    {
        public PageRequest PageRequest { get; set; }

        public bool BypassCache { get; set; }
        public string CacheKey => "colors-list";
        public TimeSpan? SlidingExpiration { get; set; }

        public class GetColorListQueryHandler : IRequestHandler<GetColorListQuery, ColorListModel>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public GetColorListQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<ColorListModel> Handle(GetColorListQuery request, CancellationToken cancellationToken)
            {
                var colors = await _colorRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedColors = _mapper.Map<ColorListModel>(colors);
                return mappedColors;
            }
        }
    }
}
