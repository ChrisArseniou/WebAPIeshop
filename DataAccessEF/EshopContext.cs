using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccessEF
{

    /// <summary>
    /// The EshopContext class is responsible for connecting to the database and managing the DbSet properties. It inherits the 
    /// DbContext Class.
    /// </summary>
    public class EshopContext : DbContext
    {

        public EshopContext() { }

        /// <summary>
        /// Constructor that accepts DbContextOptions as parameter
        /// </summary>
        /// <param name="options"></param>
        public EshopContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet for the Customer table
        /// </summary>
        public DbSet<Customer> Customer
        {
            get;
            set;
        }

        /// <summary>
        /// DbSet for the Item table
        /// </summary>
        public DbSet<Item> Item
        {
            get;
            set;
        }

        /// <summary>
        /// DbSet for the Order table
        /// </summary>
        public DbSet<Order> Order
        {
            get;
            set;
        }

        /// <summary>
        /// DbSet for the product table
        /// </summary>
        public DbSet<Product> Product
        {
            get;
            set;
        }
    }
}
