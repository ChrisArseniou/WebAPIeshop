using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF
{

    /// <summary>
    /// The GenericRepository class is a generic implementation of the IGenericRepository interface,
    /// it provides basic CRUD functionality for any type of entity.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EshopContext context;

        /// <summary>
        /// Constructor that accepts context as parameter
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(EshopContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Method to add an entity to the context
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Method to get all entities of the context
        /// </summary>
        /// <returns>A set of all entities</returns>
        public IEnumerable<T> GetAll()
        {
            //return context.Set<T>().ToList();
            return context.Set<T>();
        }

        /// <summary>
        /// Method to get an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns the entity with the specific id</returns>
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        /// <summary>
        /// Method to remove an entity from the context
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
    }
}
