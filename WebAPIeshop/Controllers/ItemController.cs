using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIeshop.Controllers
{

    /// <summary>
    /// A controller for managing items.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>An enumerable of all items.</returns>
        [HttpGet]
        public IEnumerable<Item> GetAllItems()
        {
            return unitOfWork.Item.GetAll();
        }

        /// <summary>
        /// Gets an item by id.
        /// </summary>
        /// <param name="id">The id of the item.</param>
        /// <returns>The item with the specified id.</returns>
        [HttpGet]
        [Route("{id:int}")]
        public Item GetItemById(int id)
        {
            Item entity = unitOfWork.Item.GetById(id);
            return entity;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns>The added item</returns>
        [HttpPost]
        public ActionResult AddItem(Item newItem)
        {

            unitOfWork.Item.Add(newItem);
            
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
        /// Deletes an item by id.
        /// </summary>
        /// <param name="id">The id of the item to delete.</param>
        /// <returns>The deleted item</returns>
        [HttpDelete]
        public ActionResult DeleteItem(int id)
        {

            var entity = unitOfWork.Item.GetById(id);
            unitOfWork.Item.Remove(entity);
            
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
