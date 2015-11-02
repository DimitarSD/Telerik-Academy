namespace MusicStore.Api.App_Start
{
    using System.Data.Entity;

    using MusicStore.Data;
    using MusicStore.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreDbContext, Configuration>());
            MusicStoreDbContext.Create().Database.Initialize(true);
        }
    }
}