using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarDamages.Dtos
{
    public class UpdateCarDamageDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string DamageDetail { get; set; }
    }
}
