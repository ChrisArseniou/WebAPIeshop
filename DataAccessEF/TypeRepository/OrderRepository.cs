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
    /// Order Repository inhererits the Generic Repository class and the Order Repository Interface
    /// </summary>
    class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EshopContext context) : base(context) { }

    }

    
}