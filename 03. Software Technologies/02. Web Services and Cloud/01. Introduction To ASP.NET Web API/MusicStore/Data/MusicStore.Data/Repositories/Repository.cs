namespace MusicStore.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using MusicStore.Data.Contracts;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMusicStoreDbContext data;
        private readonly IDbSet<TEntity> set;

        public Repository() 
            : this(new MusicStoreDbContext())
        {
        }
        
        public Repository(IMusicStoreDbContext data)
        {
            this.data = data;
            this.set = data.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<TEntity> All()
        {
            return this.set;
        }

        public TEntity FindById(object id)
        {
            return this.set.Find(id);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }
        
        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.data.SaveChanges();
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var dbEntry = this.data.Entry(entity);
            dbEntry.State = state;
        }
    }
}
