using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car : Entity
    {
        public Car()
        {
            CarDamages = new HashSet<CarDamage>();
            Rentals = new HashSet<Rental>();
        }

        public Car(int id, int colorId, int modelId, int cityId, string plate, int kilometer, short modelYear, CarState carState) : this()
        {
            Id = id;
            ColorId = colorId;
            ModelId = modelId;
            CityId = cityId;
            Plate = plate;
            Kilometer = kilometer;
            ModelYear = modelYear;
            CarState = carState;
        }

        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public int CityId { get; set; }
        public string Plate { get; set; }
        public int Kilometer { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }

        public virtual Color Color { get; set; }
        public virtual Model Model { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<CarDamage> CarDamages { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
