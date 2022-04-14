using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            Rentals = new HashSet<Rental>();
        }

        public Customer(int id, string email) : this()
        {
            Email = email;
            Id = id;
        }

        public string Email { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
