namespace MusicStore.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using MusicStore.Data.Contracts;
    using Repositories;

    public class MusicStoreData : IMusicStoreData
    {
        private readonly IMusicStoreDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public MusicStoreData()
            : this(new MusicStoreDbContext())
        {
        }

        public MusicStoreData(IMusicStoreDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Gets the specific repository
        /// </summary>
        /// <typeparam name="T">Type of the repository to be created</typeparam>
        /// <returns>Returns repository of type T</returns>
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
