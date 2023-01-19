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
    /// Item repository inhererits the Generic Repository class and the Item Repository Interface
    /// </summary>
    class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(EshopContext context) : base(context) { }
    }
}