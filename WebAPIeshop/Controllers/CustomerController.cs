using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;

namespace WebAPIeshop.Controllers
{

    /// <summary>
    /// A controller for managing customers.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CustomerController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>An enumerable of all customers.</returns>
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return unitOfWork.Customer.GetAll();
        }

        /// <summary>
        /// Gets a customer by id.
        /// </summary>
        /// <param name="id">The id of the customer.</param>
        /// <returns>The customer with the specified id.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public Customer GetCustomerById([FromRoute] int id)
        {
            Customer entity = unitOfWork.Customer.GetById(id);
            return entity;
        }

        /// <summary>
        /// Add customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns>The added customer</returns>
        [HttpPost]
        public ActionResult AddCustomer(Customer newCustomer) 
        {

            unitOfWork.Customer.Add(newCustomer);
            int saved = unitOfWork.Save();
            if (saved != 0)
                Console.WriteLine("Success");
            else 
            {
                Console.WriteLine("Error");
            }
            return Ok();

        }

        /// <summary>
        /// Edits a Customer by ID.
        /// </summary>
        /// <param name="id">The ID of the Customer to edit</param>
        /// <param name="updateCustomerRequest">The updated Customer information.</param>
        /// <returns>The updated Customer.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public Customer EditById([FromRoute] int id, Customer updateCustomerRequest)
        {
            Customer CustomerToUpdate = unitOfWork.Customer.GetById(id);

            Console.WriteLine(CustomerToUpdate.FirstName);
            CustomerToUpdate.FirstName = updateCustomerRequest.FirstName;
            CustomerToUpdate.LastName= updateCustomerRequest.LastName;
            CustomerToUpdate.Address = updateCustomerRequest.Address;
            CustomerToUpdate.PostalCode = updateCustomerRequest.PostalCode;
            //CustomerToUpdate.Orders = updateCustomerRequest.Orders;

            int saved = unitOfWork.Save();
            if (saved != 0)
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Error");
            }

            return CustomerToUpdate;
        }

        /// <summary>
        /// Views customer orders, sorted by date
        /// </summary>
        /// <param name="id">The ID of the Customer we want to check the orders</param>
        /// <returns>An iteratable list of customer's orders, sorted by date</returns>
        
        [HttpGet]
        [Route("Orders/{id:int}")]
        public IEnumerable<Order> IterateThroughOrders([FromRoute] int id) 
        {

            var entity = unitOfWork.Order.GetAll().ToList().Where(a => a.CustomerId == id).OrderBy(a => a.OrderDate);
            return entity;

        }


        /// <summary>
        /// Deletes a customer by id.
        /// </summary>
        /// <param name="id">The id of the customer to delete.</param>
        /// <returns>The deleted customer</returns>
        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {

            Customer entity = unitOfWork.Customer.GetById(id);
            unitOfWork.Customer.Remove(entity);
            int saved = unitOfWork.Save();
            if (saved != 0)
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Error");
            }
            return Ok();

        }
    }
}
