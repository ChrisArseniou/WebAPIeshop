using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    /// <summary>
    /// Represents a customer in the system.
    /// </summary>
    public class Customer
    {

        /// <summary>
        /// The unique identifier for the customer.
        /// </summary>

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Customer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Customer's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Customer's postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// A list of orders placed by the customer.
        /// </summary>
        //public Order Orders { get; set; }

    }
}
