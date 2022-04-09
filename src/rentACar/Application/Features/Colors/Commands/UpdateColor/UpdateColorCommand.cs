using Application.Features.Colors.Dtos;
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

namespace Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommand : IRequest<UpdateColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdateColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<UpdateColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var colorToBeUpdated = await _colorRepository.GetAsync(c => c.Id == request.Id);
                if (colorToBeUpdated is null)
                    throw new BusinessException("Böyle bir renk bulunamadı!");

                Color mappedColor = _mapper.Map<Color>(request);
                var updatedColor = _colorRepository.UpdateAsync(mappedColor);
                UpdateColorDto updateColorDto = _mapper.Map<UpdateColorDto>(updatedColor);
                return updateColorDto;
            }
        }
    }
}
