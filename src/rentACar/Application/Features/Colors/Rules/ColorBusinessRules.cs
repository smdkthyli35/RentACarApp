using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Rules
{
    public class ColorBusinessRules
    {
        private readonly IColorRepository _colorRepository;

        public ColorBusinessRules(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task ColorNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _colorRepository.GetListAsync(c => c.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Bu renk adı daha önceden eklenmiş. Lütfen farklı bir renk adı giriniz.");
            }
        }
    }
}
