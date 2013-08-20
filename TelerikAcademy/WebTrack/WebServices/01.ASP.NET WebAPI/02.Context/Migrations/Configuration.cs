namespace _02.Context.Migrations
{
    using _01.Classes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_02.Context.AlbumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_02.Context.AlbumContext context)
        {
            Artist firstArtist = new Artist();
            firstArtist.Name = "Jack Flakes";
            firstArtist.Country = "USA";
            firstArtist.DateOfBirth = new DateTime(1970, 11, 11);

            Artist secondArtist = new Artist();
            secondArtist.Name = "Robbie Jones";
            secondArtist.Country = "UK";
            secondArtist.DateOfBirth = new DateTime(1982, 10, 3);

            Album firstAlbum = new Album();
            firstAlbum.Title = "Jack Flakes' album";
            firstAlbum.Year = 2010;
            firstAlbum.Producer = "Jack Flakes' producer";
            firstAlbum.Artists.Add(firstArtist);

            Album secondAlbum = new Album();
            secondAlbum.Title = "Robbie Jones' album";
            secondAlbum.Year = 2011;
            secondAlbum.Producer = "Robbie Jones' producer";
            secondAlbum.Artists.Add(secondArtist);

            Song firstSong = new Song();
            firstSong.Genre = "blues";
            firstSong.Title = "Blues song";
            firstSong.Year = 2010;
            firstSong.Artists.Add(firstArtist);
            firstAlbum.Songs.Add(firstSong);

            Song secondSong = new Song();
            secondSong.Genre = "jazz";
            secondSong.Title = "Jazz song";
            secondSong.Year = 2010;
            secondSong.Artists.Add(secondArtist);
            secondAlbum.Songs.Add(secondSong);

            context.Albums.AddOrUpdate(a => a.Title, firstAlbum);
            context.Albums.AddOrUpdate(a => a.Title, secondAlbum);

            context.SaveChanges();
        }
    }
}
