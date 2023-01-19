using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{

    /// <summary>
    /// The IOrderRepository interface defines the methods that a OrderRepository class should implement,
    /// it inherits from the IGenericRepository interface.
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Order> { }
}
