using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarDamage : Entity
    {
        public CarDamage()
        {

        }

        public CarDamage(int id, int carId, Car car, string damageDetail) : base(id)
        {
            CarId = carId;
            DamageDetail = damageDetail;
        }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public string DamageDetail { get; set; }
    }
}
