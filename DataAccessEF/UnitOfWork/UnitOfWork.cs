using DataAccessEF.TypeRepository;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.UnitOfWork
{
    /// <summary>
    /// The UnitOfWork class is responsible for managing the repositories and saving changes to the database
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private EshopContext context;

        /// <summary>
        /// Constructor Of Unit of Work. Initializes each repository
        /// </summary>
        /// <param name="context">Context contains the Database Set of each table</param>
        public UnitOfWork(EshopContext context)
        {
            this.context = context;
            Customer = new CustomerRepository(this.context);
            Item = new ItemRepository(this.context);
            Order = new OrderRepository(this.context);
            Product = new ProductRepository(this.context);
           
        }

        /// <summary>
        /// Repository for the customer table
        /// </summary>
        public ICustomerRepository Customer
        {
            get;
            private set;
        }

        /// <summary>
        /// Repository for the item table
        /// </summary>
        public IItemRepository Item
        {
            get;
            private set;
        }

        /// <summary>
        /// Repository for the order table
        /// </summary>
        public IOrderRepository Order
        {
            get;
            private set;
        }

        /// <summary>
        /// Repository for the product table
        /// </summary>
        public IProductRepository Product
        {
            get;
            private set;
        }

        /// <summary>
        /// Dispose method to dispose the context
        /// </summary>
        public void Dispose()
        {
            context.Dispose();
        }

        /// <summary>
        /// Saves the changes in the database that we have access with the unit of work
        /// </summary>
        /// <returns>Returns the saved context</returns>
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
