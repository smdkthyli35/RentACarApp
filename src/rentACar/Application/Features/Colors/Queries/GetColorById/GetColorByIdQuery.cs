using Application.Features.Brands.Dtos;
using Application.Features.Colors.Dtos;
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

namespace Application.Features.Colors.Queries.GetColorById
{
    public class GetColorByIdQuery : IRequest<ColorDto>
    {
        public int Id { get; set; }

        public class GetColorByIdQueryHandler : IRequestHandler<GetColorByIdQuery, ColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public GetColorByIdQueryHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<ColorDto> Handle(GetColorByIdQuery request, CancellationToken cancellationToken)
            {
                var colorIsTheExists = await _colorRepository.GetAsync(b => b.Id == request.Id);
                if (colorIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir renk bulunamadı!");
                else
                {
                    ColorDto colorDto = _mapper.Map<ColorDto>(colorIsTheExists);
                    return colorDto;
                }
            }
        }
    }
}
