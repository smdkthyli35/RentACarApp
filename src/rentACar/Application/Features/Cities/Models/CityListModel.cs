using Application.Features.Cities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Models
{
    public class CityListModel
    {
        public IList<CityListDto> Items { get; set; }
    }
}
