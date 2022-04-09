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

namespace Application.Features.Colors.Commands.DeleteColor
{
    public class DeleteColorCommand : IRequest<DeleteColorDto>
    {
        public int Id { get; set; }

        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeleteColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;

            public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
            }

            public async Task<DeleteColorDto> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var colorToBeDeleted = await _colorRepository.GetAsync(c => c.Id == request.Id);
                if (colorToBeDeleted is null)
                    throw new BusinessException("Böyle bir renk bulunamadı!");

                Color mappedColor = _mapper.Map<Color>(request);
                var deletedColor = _colorRepository.DeleteAsync(mappedColor);
                DeleteColorDto deleteColorDto = _mapper.Map<DeleteColorDto>(deletedColor);
                return deleteColorDto;
            }
        }
    }
}
