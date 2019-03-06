namespace Movie.Migrations
{
    using Movie.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Movie.DAL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Movie.DAL.DataContext context)
        {
          
            context.Users.AddOrUpdate(x => x.UserId,
                new User() { UserId=1, Name="Ammar", LastName="Hakanovic", Password="1234", UserName="gunner"}
               
                );


            context.Films.AddOrUpdate(x => x.FilmId,
                new Film() { FilmId=1, Name="Ovo malo duse", Zanrovi="Domaci" },
                new Film() { FilmId = 2, Name = "Bitka na Neretvi", Zanrovi = "Domaci" },
                new Film() { FilmId = 3, Name = "Red Sparrow", Zanrovi = "Akcija" }

                );


            context.Genres.AddOrUpdate(x => x.GenreId,
                new Genre() { GenreId=1, Zanrovi="Domaci", },
                new Genre() { GenreId = 1, Zanrovi = "Akcija", }

                );
        }
    }
}
