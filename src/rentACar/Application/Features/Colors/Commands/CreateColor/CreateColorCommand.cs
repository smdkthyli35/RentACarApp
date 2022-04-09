using Application.Features.Colors.Dtos;
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

namespace Application.Features.Colors.Commands.CreateColor
{
    public class CreateColorCommand : IRequest<CreateColorDto>
    {
        public string Name { get; set; }

        public class CreateColorCommandHandler : IRequestHandler<CreateColorCommand, CreateColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public CreateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<CreateColorDto> Handle(CreateColorCommand request, CancellationToken cancellationToken)
            {
                Color mappedColor = _mapper.Map<Color>(request);
                Color createdColor = await _colorRepository.AddAsync(mappedColor);
                CreateColorDto createColorDto = _mapper.Map<CreateColorDto>(createdColor);
                return createColorDto;
            }
        }
    }
}
