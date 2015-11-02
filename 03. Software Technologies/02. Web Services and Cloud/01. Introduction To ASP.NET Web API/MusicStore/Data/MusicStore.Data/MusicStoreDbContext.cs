namespace MusicStore.Data
{
    using System.Data.Entity;

    using Common.Constants;
    using Contracts;
    using Models;

    public class MusicStoreDbContext : DbContext, IMusicStoreDbContext
    {
        public MusicStoreDbContext() 
            : base("MusicStoreDb")
        {
        }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Artist> Artist { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public static MusicStoreDbContext Create()
        {
            return new MusicStoreDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
