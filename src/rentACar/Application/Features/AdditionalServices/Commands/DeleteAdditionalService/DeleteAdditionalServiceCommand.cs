using Application.Features.AdditionalServices.Dtos;
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

namespace Application.Features.AdditionalServices.Commands.DeleteAdditionalService
{
    public class DeleteAdditionalServiceCommand : IRequest<DeleteAdditionalServiceDto>
    {
        public int Id { get; set; }

        public class DeleteAdditionalServiceCommandHandler : IRequestHandler<DeleteAdditionalServiceCommand, DeleteAdditionalServiceDto>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public DeleteAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<DeleteAdditionalServiceDto> Handle(DeleteAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                var additionalServiceToBeDeleted = await _additionalServiceRepository.GetAsync(a => a.Id == request.Id);
                if (additionalServiceToBeDeleted is null)
                    throw new BusinessException("Böyle bir ek hizmet bulunamadı!");

                AdditionalService mappedAdditionalService = _mapper.Map<AdditionalService>(request);
                var deletedAdditionalService = _additionalServiceRepository.DeleteAsync(mappedAdditionalService);
                DeleteAdditionalServiceDto deleteAdditionalServiceDto = _mapper.Map<DeleteAdditionalServiceDto>(deletedAdditionalService);
                return deleteAdditionalServiceDto;
            }
        }
    }
}
