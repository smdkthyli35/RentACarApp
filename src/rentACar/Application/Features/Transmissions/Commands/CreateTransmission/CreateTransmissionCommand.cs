using Application.Features.Transmissions.Dtos;
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

namespace Application.Features.Transmissions.Commands.CreateTransmission
{
    public class CreateTransmissionCommand : IRequest<CreateTransmissionDto>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreateTransmissionDto>
        {
            private readonly ITransmissionRepository _transmissionRepository;
            private readonly IMapper _mapper;

            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<CreateTransmissionDto> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                var mappedTransmission = _mapper.Map<Transmission>(request);
                var createdTransmission = await _transmissionRepository.AddAsync(mappedTransmission);
                var createTransmissionDto = _mapper.Map<CreateTransmissionDto>(createdTransmission);
                return createTransmissionDto;
            }
        }
    }
}
