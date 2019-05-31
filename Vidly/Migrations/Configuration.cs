namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (context.Customers.Count() == 0)
            {

                List<Customer> customers = new List<Customer>
                {
                    new Customer {Name = "Tugay Evci",MembershipTypeId=1,IsSubscribedToNewsLetter=false,Birthdate=new DateTime(1995-05-03) },
                    new Customer {Name = "Gülçin Boztürk",MembershipTypeId=4,IsSubscribedToNewsLetter=true,Birthdate=new DateTime(1995-03-20) },
                    new Customer {Name = "Burak Gülmez",MembershipTypeId=2,IsSubscribedToNewsLetter=false},
                    new Customer {Name = "Azra Gülmez",MembershipTypeId=1,IsSubscribedToNewsLetter=false,Birthdate=new DateTime(2005-01-09) },
                    new Customer {Name = "Metin Gökduman",MembershipTypeId=3,IsSubscribedToNewsLetter=true }
                };

                context.Customers.AddRange(customers);
            }

            if (context.Genres.Count() == 0)
            {
                List<Genre> genres = new List<Genre>{
                    new Genre {Name="Action"},
                    new Genre {Name="Adventure"},
                    new Genre {Name="Comedy"},
                    new Genre {Name="Crime"},
                    new Genre {Name="Drama"},
                    new Genre {Name="Horror"}
                };

                context.Genres.AddRange(genres);
            }

            //if (context.Movies.Count() == 0)
            //{
            //    List<Movie> movies = new List<Movie>
            //    {
            //        new Movie {Name=""}
            //    } 
            //}

        }
    }
}
