using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
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

namespace Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<BrandDto>
    {
        public int Id { get; set; }

        public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
            {
                var brandIsTheExists = await _brandRepository.GetAsync(b => b.Id == request.Id);
                if (brandIsTheExists is null)
                    throw new BusinessException($"{request.Id} id'li böyle bir marka bulunamadı!");
                else
                {
                    BrandDto brandDto = _mapper.Map<BrandDto>(brandIsTheExists);
                    return brandDto;
                }
            }
        }
    }
}
