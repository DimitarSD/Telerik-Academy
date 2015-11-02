namespace MusicStore.Data.Contracts
{
    using System.Linq;

    /// <summary>
    /// Generic interface which provides us with methods for working with the data
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>
    public interface IRepository<TEntity>
    {        
        /// <summary>
        /// Creates/Adds new entity
        /// </summary>
        /// <param name="entity">Entity to be added</param>
        void Add(TEntity entity);

        /// <summary>
        /// Reads and returns all entities
        /// </summary>
        /// <returns>Returns IQueryable<TEntity></returns>
        IQueryable<TEntity> All();

        /// <summary>
        /// Updates an entity
        /// </summary>
        /// <param name="entity">Entity to be updated</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes/Removes an entity
        /// </summary>
        /// <param name="entity">Entity to be removed</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Save an entity
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Finds an entity by id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns>Returns the founded entity</returns>
        TEntity FindById(object id);
    }
}
