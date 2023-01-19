using NHibernate.Mapping;
using SQLite;
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
    /// Order class represents the Order table in the database
    /// </summary>

    public class Order
    {
        /// <summary>
        /// Order Table primary key. Choosing this one since their is a need to support orders with multiple items.
        /// </summary>
        [Key]
        public int ItemsSold { get; set; }


        /// <summary>
        /// Id of the order
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Date of the order
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Total price of the order
        /// </summary>
        public decimal TotalPrice { get; set; }


        /// <summary>
        /// Item of the order
        /// </summary>
        [ForeignKey("ItemId")]
        public int ItemId { get; set; }

        /// <summary>
        /// Customer id of the order
        /// </summary>

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
    }
}
