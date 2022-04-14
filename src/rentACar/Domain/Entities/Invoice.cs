using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice : Entity
    {
        public Invoice()
        {
            Cars = new HashSet<Car>();
        }

        public Invoice(int id, int customerId, string ınvoiceNo, DateTime createdDate, DateTime rentalStartDate, DateTime rentalEndDate, float rentalDayCount, decimal totalRentalPrice) : this()
        {
            Id = id;
            CustomerId = customerId;
            InvoiceNo = ınvoiceNo;
            CreatedDate = createdDate;
            RentalStartDate = rentalStartDate;
            RentalEndDate = rentalEndDate;
            RentalDayCount = rentalDayCount;
            TotalRentalPrice = totalRentalPrice;
        }

        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public float RentalDayCount { get; set; }
        public decimal TotalRentalPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
