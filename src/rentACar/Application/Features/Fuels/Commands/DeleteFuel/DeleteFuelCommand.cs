using Application.Features.Fuels.Dtos;
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

namespace Application.Features.Fuels.Commands.DeleteFuel
{
    public class DeleteFuelCommand : IRequest<DeleteFuelDto>
    {
        public int Id { get; set; }

        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, DeleteFuelDto>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public DeleteFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<DeleteFuelDto> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var fuelToBeDeleted = await _fuelRepository.GetAsync(f => f.Id == request.Id);
                if (fuelToBeDeleted is null)
                    throw new BusinessException("Böyle bir yakıt türü bulunamadı.");

                Fuel mappedFuel = _mapper.Map<Fuel>(request);
                var deletedFuel = _fuelRepository.DeleteAsync(mappedFuel);
                DeleteFuelDto deleteFuelDto = _mapper.Map<DeleteFuelDto>(deletedFuel);
                return deleteFuelDto;
            }
        }
    }
}
