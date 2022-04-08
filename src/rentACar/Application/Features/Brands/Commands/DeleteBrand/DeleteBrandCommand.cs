using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<DeleteBrandDto>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brandToBeDeleted = await _brandRepository.GetAsync(b => b.Id == request.Id);
                if (brandToBeDeleted is null)
                    throw new BusinessException("Böyle bir marka bulunamadı!");

                Brand mappedBrand = _mapper.Map<Brand>(request);
                var deletedBrand = _brandRepository.DeleteAsync(mappedBrand);
                DeleteBrandDto deleteBrandDto = _mapper.Map<DeleteBrandDto>(deletedBrand);
                return deleteBrandDto;
            }
        }
    }
}
