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

namespace Application.Features.Transmissions.Commands.DeleteTransmission
{
    public class DeleteTransmissionCommand : IRequest<DeleteTransmissionDto>
    {
        public int Id { get; set; }

        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, DeleteTransmissionDto>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<DeleteTransmissionDto> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmissionToBeDeleted = await _transmissionRepository.GetAsync(t => t.Id == request.Id);
                if (transmissionToBeDeleted is null)
                    throw new BusinessException("Böyle bir vites bulunamadı!");

                Transmission mappedTransmission = _mapper.Map<Transmission>(request);
                var deletedTransmission = _transmissionRepository.DeleteAsync(mappedTransmission);
                DeleteTransmissionDto deleteTransmissionDto = _mapper.Map<DeleteTransmissionDto>(deletedTransmission);
                return deleteTransmissionDto;
            }
        }
    }
}
