namespace MusicStore.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface IMusicStoreDbContext
    {
        IDbSet<Album> Albums { get; set; }

        IDbSet<Artist> Artist { get; set; }

        IDbSet<Song> Songs { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Returns an object of the specific entity that we want to manipulate. Can gets its state
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity</typeparam>
        /// <param name="entity">Entity to be used</param>
        /// <returns>Returns an object</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}
