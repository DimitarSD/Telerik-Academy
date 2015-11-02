namespace MusicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    using Common.Constants;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicStoreDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStoreDbContext context)
        {
            context.Albums.AddOrUpdate(
                a => a.Title,
                new Album
                {
                    Title = ConfigurationConstants.AlbumInitialTitle,
                    Year = ConfigurationConstants.AlbumInitialYear,
                    Producer = ConfigurationConstants.AlbumInitialProducer
                });

            context.Artist.AddOrUpdate(
                a => a.Name,
                new Artist
                {
                    Name = ConfigurationConstants.ArtistInitialName,
                    Country = ConfigurationConstants.ArtistInitialCountry,
                    DateOfBirth = new DateTime(1989, 06, 03)
                });

            context.Songs.AddOrUpdate(
                s => s.Title,
                new Song
                {
                    Title = ConfigurationConstants.SongInitialTitle,
                    Genre = ConfigurationConstants.SongInitialGenre,
                    Year = ConfigurationConstants.SongInitialYear
                });
        }
    }
}
