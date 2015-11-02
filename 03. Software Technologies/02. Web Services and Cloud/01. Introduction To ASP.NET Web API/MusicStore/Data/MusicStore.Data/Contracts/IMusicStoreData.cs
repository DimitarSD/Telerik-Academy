namespace MusicStore.Data.Contracts
{
    using MusicStore.Models;

    public interface IMusicStoreData
    {
        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Song> Songs { get; }

        void SaveChanges();
    }
}
