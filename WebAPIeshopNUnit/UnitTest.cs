using DataAccessEF;
using DataAccessEF.UnitOfWork;
using Domain;
using Domain.Interfaces;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Sockets;
using WebAPIeshop.Controllers;



namespace WebAPIeshopNUnit
{
    /// <summary>
    /// This class represents a test case for the eshop application.
    /// </summary>
    public class Tests
    {
        private EshopContext context;
        private UnitOfWork unitOfWork;

        private CustomerController CustController;
        private ProductController ProdController;
        private ItemController ItemControllerObj;
        private OrderController OrderControllerObj;


        Customer customer1, customer2, customer3, customer4;
        Product product1, product2;
        Item Item1, Item2;
        Order Order1;

        /// <summary>
        /// Sets up the test case by initializing the mock context, controllers, and test data.
        /// </summary>
        [SetUp]
        public void Setup()
        {

            var mockContext = new Mock<EshopContext>();

            context = mockContext.Object;

            var mockCust = new Mock<DbSet<Customer>>();
            var mockProduct = new Mock<DbSet<Product>>();
            var mockItem = new Mock<DbSet<Item>>();
            var mockOrder = new Mock<DbSet<Order>>();

            mockContext.Setup(c => c.Set<Customer>()).Returns(mockCust.Object);
            mockContext.Setup(c => c.Set<Product>()).Returns(mockProduct.Object);
            mockContext.Setup(c => c.Set<Item>()).Returns(mockItem.Object);
            mockContext.Setup(c => c.Set<Order>()).Returns(mockOrder.Object);

            //Customers
            customer1 = new Customer();
            customer1.Id = 1;
            customer1.FirstName = "Luka";
            customer1.LastName = "Ming";
            customer1.Address = "Tsimiski 2";
            customer1.PostalCode = "11111";
            //customer1.Orders = null;

            customer2 = new Customer();
            customer2.Id = 2;
            customer2.FirstName = "Larry";
            customer2.LastName = "Beasley";
            customer2.Address = "Agias Sofias 1";
            customer2.PostalCode = "2222";
            //customer2.Orders = null;

            customer3 = new Customer();
            customer3.Id = 3;
            customer3.FirstName = "Jordan";
            customer3.LastName = "Paul";
            customer3.Address = "Dimitriados 22";
            customer3.PostalCode = "3333";
            //customer3.Orders = null;

            customer4 = new Customer();
            customer4.Id = 4;
            customer4.FirstName = "Mike";
            customer4.LastName = "Griffin";
            customer4.Address = "Iasonos 33";
            customer4.PostalCode = "4444";
            //customer4.Orders = null;

            //Products
            product1 = new Product();
            product1.Id = 1;
            product1.Name = "Corn";
            product1.Price = 0.4m;

            product2 = new Product();
            product1.Id = 2;
            product1.Name = "barley";
            product1.Price = 0.45m;

            //Items
            Item1 = new Item();
            Item1.Id = 1;
            Item1.Quantity = 40;
            Item1.ProductId = product1.Id;

            Item2 = new Item();
            Item2.Id = 2;
            Item2.Quantity = 120;
            Item2.ProductId = product2.Id;

            //Orders
            Order1 = new Order();
            Order1.OrderNumber = 1;
            Order1.OrderDate = new DateTime(2023, 01, 11);
            Order1.TotalPrice = 120m;

            //List<Item> ItemList = new List<Item>();
            //ItemList.Add(Item1);
            //ItemList.Add(Item2);

            Order1.ItemId = Item1.Id;
            Order1.CustomerId = customer1.Id;

            unitOfWork = new UnitOfWork(context);   
        }

        /// <summary>
        /// Tests adding customers to the eshop's database.
        /// </summary>
        [Test]
        public void AddCustomer()
        {

            unitOfWork.Customer.Add(customer1);
            unitOfWork.Customer.Add(customer2);

            Assert.Pass();
        }

        /// <summary>
        /// Tests adding products to the eshop's database.
        /// </summary>
        [Test]
        public void AddProduct() 
        {
            unitOfWork.Product.Add(product1);
            unitOfWork.Product.Add(product2);
            Assert.Pass();
        }

        /// <summary>
        /// Tests adding items to the eshop's database.
        /// </summary>
        [Test]
        public void AddItem() 
        {

            unitOfWork.Item.Add(Item1);
            unitOfWork.Item.Add(Item2);

            Assert.Pass();
        }

        /// <summary>
        /// Tests adding orders to the eshop's database.
        /// </summary>
        [Test]
        public void AddOrder() 
        {
            unitOfWork.Order.Add(Order1);
            Assert.Pass();
        }

        /// <summary>
        /// This test case creates a new instance of the customer controller.
        /// </summary>
        [Test]
        public void CreateCustomerControllerTest()
        {

            CustController = new CustomerController(unitOfWork);
            Assert.Pass();
        }

        public void UpdateCustomer()
        {

            unitOfWork.Customer.Add(customer3);
            unitOfWork.Customer.Add(customer4);
            unitOfWork.Save();
            CustController = new CustomerController(unitOfWork);
            CustController.EditById(customer3.Id, customer4);
            Customer updatedCustomer = unitOfWork.Customer.GetById(customer3.Id);

            if (updatedCustomer.LastName == customer4.LastName)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        /// <summary>
        /// This test case creates a new instance of the product controller.
        /// </summary>
        [Test]
        public void CreateProductControllerTest()
        {

            ProdController = new ProductController(unitOfWork);
            Assert.Pass();
        }

        /// <summary>
        /// This test case creates a new instance of the item controller.
        /// </summary>
        [Test]
        public void CreateItemControllerTest()
        {

            ItemControllerObj = new ItemController(unitOfWork);
            Assert.Pass();
        }

        /// <summary>
        /// This test case creates a new instance of the order controller.
        /// </summary>
        [Test]
        public void CreateOrderControllerTest()
        {
            OrderControllerObj = new OrderController(unitOfWork);
            Assert.Pass();
        }

        /// <summary>
        /// This test case retrieves a list of all customers.
        /// </summary>
        [Test]
        public void GetAllCustomers()
        {

            var Customerlist = CustController.GetAllCustomers();
            if (Customerlist == null)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        /// <summary>
        /// This test case retrieves a list of all products.
        /// It passese 
        /// </summary>
        [Test]
        public void GetAllProducts()
        {

            var Productlist = ProdController.GetAllProducts();
            if (Productlist == null) 
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        /// <summary>
        /// This test case retrieves a list of all items.
        /// </summary>
        [Test]
        public void GetAllItems()
        {

            var Itemlist = ItemControllerObj.GetAllItems();
            if (Itemlist == null)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        /// <summary>
        /// This test case retrieves a list that contains all the orders.
        /// </summary>

        [Test]
        public void GetAllOrders()
        {

            var Orderlist = OrderControllerObj.GetAllOrders();
            if (Orderlist == null)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}