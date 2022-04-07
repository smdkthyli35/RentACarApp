using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Response;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<NoContent>
    {
        public int Id { get; set; }

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, NoContent>
        {
            private readonly IBrandRepository _brandRepository;

            public DeleteBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
            }

            public async Task<NoContent> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = await _brandRepository.GetAsync(b => b.Id == request.Id);

                if (brand == null)
                    throw new BusinessException("Böyle bir marka bulunamadı!");

                await _brandRepository.DeleteAsync(brand);
                return new NoContent();
            }
        }
    }
}
