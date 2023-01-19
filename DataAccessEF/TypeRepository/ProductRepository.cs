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
    /// Product Repository inhererits the Generic Repository class and the Product Repository Interface
    /// </summary>
    class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EshopContext context) : base(context) { }
    }
}