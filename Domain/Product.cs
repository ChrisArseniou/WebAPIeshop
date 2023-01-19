using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    /// <summary>
    /// Product class represents the product table in the database
    /// </summary>
    public class Product
    {

        /// <summary>
        /// Id of the product
        /// </summary>

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        //public List<Item> Items { get; set; }
    }
}
