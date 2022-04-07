using Application.Features.Brands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Models
{
    public class BrandListModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
