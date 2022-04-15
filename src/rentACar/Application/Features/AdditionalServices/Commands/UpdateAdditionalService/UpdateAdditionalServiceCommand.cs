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

namespace Application.Features.AdditionalServices.Commands.UpdateAdditionalService
{
    public class UpdateAdditionalServiceCommand : IRequest<UpdateAdditionalServiceDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }

        public class UpdateAdditionalServiceCommandHandler : IRequestHandler<UpdateAdditionalServiceCommand, UpdateAdditionalServiceDto>
        {
            private readonly IAdditionalServiceRepository _additionalServiceRepository;
            private readonly IMapper _mapper;

            public UpdateAdditionalServiceCommandHandler(IAdditionalServiceRepository additionalServiceRepository, IMapper mapper)
            {
                _additionalServiceRepository = additionalServiceRepository;
                _mapper = mapper;
            }

            public async Task<UpdateAdditionalServiceDto> Handle(UpdateAdditionalServiceCommand request, CancellationToken cancellationToken)
            {
                var additionalServiceToBeUpdated = await _additionalServiceRepository.GetAsync(a => a.Id == request.Id);
                if (additionalServiceToBeUpdated is null)
                    throw new BusinessException("Böyle bir ek hizmet bulunamadı!");

                AdditionalService mappedAdditionalService = _mapper.Map<AdditionalService>(request);
                var updatedAdditionalService = _additionalServiceRepository.UpdateAsync(mappedAdditionalService);
                UpdateAdditionalServiceDto updateAdditionalServiceDto = _mapper.Map<UpdateAdditionalServiceDto>(updatedAdditionalService);
                return updateAdditionalServiceDto;
            }
        }
    }
}
