using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.TypeRepository
{
    /// <summary>
    /// Customer repository inhererits the Generic Repository class and the Customer Repository Interface
    /// </summary>
    class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EshopContext context) : base(context) { }
    }
}
