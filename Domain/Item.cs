using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    /// <summary>
    /// Item class represents the item table in the database
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Id of the item
        /// </summary>

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Quantity of the item
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Product id of the item
        /// </summary>
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

    }
}
