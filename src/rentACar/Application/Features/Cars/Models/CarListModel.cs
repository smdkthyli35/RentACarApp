using Application.Features.Cars.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Models
{
    public class CarListModel
    {
        public IList<CarListDto> Items { get; set; }
    }
}
