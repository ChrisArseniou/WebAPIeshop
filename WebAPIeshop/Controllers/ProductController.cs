using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIeshop.Controllers
{

    /// <summary>
    /// A controller for managing products.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>An enumerable of all products.</returns>
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return unitOfWork.Product.GetAll();
        }

        /// <summary>
        /// Gets a product by id.
        /// </summary>
        /// <param name="id">The id of the product.</param>
        /// <returns>The product with the specified id.</returns>
        [HttpGet]
        [Route("{id:guid}")]
        public Product GetProductById(int id)
        {
            Product entity = unitOfWork.Product.GetById(id);
            return entity;
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns>The added product</returns>
        [HttpPost]
        public ActionResult AddProduct(Product newProduct)
        {

            unitOfWork.Product.Add(newProduct);
            
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
        /// Edits a Product by ID.
        /// </summary>
        /// <param name="id">The ID of the Product to edit</param>
        /// <param name="updateProductRequest">The updated Product information.</param>
        /// <returns>The updated Product.</returns>
        [HttpPut]
        [Route("{id:int}")]
        public Product EditById([FromRoute] int id, Product updateProductRequest)
        {
            Product ProductToUpdate = GetProductById(id);

            ProductToUpdate.Name = updateProductRequest.Name;
            ProductToUpdate.Price = updateProductRequest.Price;

            int saved = unitOfWork.Save();
            if (saved != 0)
                Console.WriteLine("Success");
            else
            {
                Console.WriteLine("Error");
            }

            return ProductToUpdate;
        }

        /// <summary>
        /// Deletes a product by id.
        /// </summary>
        /// <param name="id">The id of the product to delete.</param>
        /// <returns>The deleted product</returns>
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {

            Product entity = unitOfWork.Product.GetById(id);
            unitOfWork.Product.Remove(entity);
            
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
