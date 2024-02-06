using Microsoft.EntityFrameworkCore;

namespace Inventory.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add an element to the Entity table
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Add a range of elements to the Entity table
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update an Entity in the table
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Update a range of entities in a table
        /// </summary>
        /// <param name="entities"></param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Sets the IsDeleted property of an enitity to true
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Sets the IsDeleted property of a range of elements to true
        /// </summary>
        /// <param name="entities"></param>
        void DeleteRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Gets the first occurance of an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Gets a range of entities from a table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ICollection<TEntity> GetAll(ICollection<Guid>? ids);
    }
}