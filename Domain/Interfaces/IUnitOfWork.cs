using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{

    /// <summary>
    /// The IUnitOfWork interface defines the methods that a UnitOfWork class should implement
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Property for the ICustomerRepository
        /// </summary>
        ICustomerRepository Customer
        {
            get;
        }

        /// <summary>
        /// Property for the IItemRepository
        /// </summary>
        IItemRepository Item
        {
            get;
        }

        /// <summary>
        /// Property for the IOrderRepository
        /// </summary>
        IOrderRepository Order
        {
            get;
        }

        /// <summary>
        /// Property for the IProductRepository
        /// </summary>
        IProductRepository Product
        {
            get;
        }

        /// <summary>
        /// Method to save the changes
        /// </summary>
        /// <returns></returns>
        int Save();
    }
}
