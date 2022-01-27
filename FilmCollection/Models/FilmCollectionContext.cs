using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class FilmCollectionContext : DbContext
    {
        //Constructor
        public FilmCollectionContext (DbContextOptions<FilmCollectionContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<Movies> responses { get; set; }

        //Seed the database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieId = 1,
                    category = "Action/Adventure",
                    title = "Captain America Winter Soldier",
                    year = 2014,
                    director = "Anthony & Joe Russo",
                    rating = "PG-13",
                    edited = false,
                    lentTo = "",
                    notes = "Best Captain America movie."
                },
                new Movies
                {
                    MovieId = 2,
                    category = "Romance",
                    title = "The Princess Bride",
                    year = 1987,
                    director = "Rob Reiner",
                    rating = "PG",
                    edited = false,
                    lentTo = "Shannon",
                    notes = "One of the greatest movies ever. End of story."
                },
                new Movies
                {
                    MovieId = 3,
                    category = "Rom-Com",
                    title = "While you were Sleeping",
                    year = 1995,
                    director = "John Turteltaub",
                    rating = "PG",
                    edited = false,
                    lentTo = "",
                    notes = ""
                }
                );
        }
    }
}
