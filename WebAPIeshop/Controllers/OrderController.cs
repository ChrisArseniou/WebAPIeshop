using Domain.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIeshop.Controllers
{

    /// <summary>
    /// A controller for managing orders.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>An enumerable of all orders.</returns>
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return unitOfWork.Order.GetAll();
        }

        /// <summary>
        /// Gets an order by id.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <returns>The order with the specified id.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public Order GetOrderById([FromRoute] int id)
        {
            var entity = unitOfWork.Order.GetById(id);
            return entity;
        }

        /// <summary>
        /// Gets an order by id.
        /// </summary>
        /// <param name="id">The id of the order.</param>
        /// <returns>The order with the specified id.</returns>
        [HttpGet]
        [Route("api/{id:int}")]
        public IEnumerable<Order> GetOrderByOrderId([FromRoute] int id)
        {
            var entity = unitOfWork.Order.GetAll().ToList().Where(a => a.OrderNumber == id);
            return entity;
        }


        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns>The added order</returns>
        [HttpPost]
        public ActionResult AddOrder(Order newOrder)
        {
            /*
            foreach(int itemId in newOrder.Items)
            {
                Order newOrderBreakDown = new Order();
                newOrderBreakDown.ItemsSold = newOrder.ItemsSold;
                newOrderBreakDown.OrderNumber = newOrder.OrderNumber;
                newOrderBreakDown.OrderDate = newOrder.OrderDate;
                newOrderBreakDown.TotalPrice = newOrder.TotalPrice;
                newOrderBreakDown.ItemId = newOrder.ItemId;
                newOrderBreakDown.CustomerId = newOrder.CustomerId;
                newOrderBreakDown.Items = null;
                unitOfWork.Order.Add(newOrderBreakDown);

            }*/

            unitOfWork.Order.Add(newOrder);

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
        /// Edits an Order by ID.
        /// </summary>
        /// <param name="id">The ID of the Order to edit.</param>
        /// <param name="updateOrderRequest">The updated Order information.</param>
        /// <returns>The updated Order.</returns>
        [HttpPut]
        [Route("{id:guid}")]
        public Order EditById([FromRoute] int id, Order updateOrderRequest)
        {
            Order OrderToUpdate = GetOrderById(id);

            OrderToUpdate.OrderDate = updateOrderRequest.OrderDate;
            OrderToUpdate.TotalPrice = updateOrderRequest.TotalPrice;
            OrderToUpdate.ItemId = updateOrderRequest.ItemId;

            int saved = unitOfWork.Save();
            if (saved != 0)
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Error");
            }

            return OrderToUpdate;
        }

        /// <summary>
        /// Deletes an order by id.
        /// </summary>
        /// <param name="id">The id of the order to delete.</param>
        /// <returns>The deleted order</returns>
        [HttpDelete]
        public ActionResult DeleteOrder(int id)
        {

            Order entity = unitOfWork.Order.GetById(id);
            unitOfWork.Order.Remove(entity);

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
