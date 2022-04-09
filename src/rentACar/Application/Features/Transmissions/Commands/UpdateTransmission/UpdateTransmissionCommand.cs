using Application.Features.Transmissions.Dtos;
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

namespace Application.Features.Transmissions.Commands.UpdateTransmission
{
    public class UpdateTransmissionCommand : IRequest<UpdateTransmissionDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdateTransmissionDto>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<UpdateTransmissionDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmissionToBeUpdated = await _transmissionRepository.GetAsync(t => t.Id == request.Id);
                if (transmissionToBeUpdated is null)
                    throw new BusinessException("Böyle bir vites bulunamadı!");

                var mappedTransmission = _mapper.Map<Transmission>(request);
                var updatedTransmission = _transmissionRepository.UpdateAsync(mappedTransmission);
                UpdateTransmissionDto updateTransmissionDto = _mapper.Map<UpdateTransmissionDto>(updatedTransmission);
                return updateTransmissionDto;
            }
        }
    }
}
