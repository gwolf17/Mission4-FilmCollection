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

        public DbSet<Movies> responses { get; set; } //Movies model
        public DbSet<Category> category { get; set; } //Category model

        //Seed the database
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    categoryId = 1,
                    categoryName = "Action/Adventure"
                },
                new Category
                {
                    categoryId = 2,
                    categoryName = "Comedy"
                },
                new Category
                {
                    categoryId = 3,
                    categoryName = "Drama"
                },
                new Category
                {
                    categoryId = 4,
                    categoryName = "Family"
                },
                new Category
                {
                    categoryId = 5,
                    categoryName = "Horror/Suspense"
                },
                new Category
                {
                    categoryId = 6,
                    categoryName = "Miscellaneous"
                },
                new Category
                {
                    categoryId = 7,
                    categoryName = "Romance"
                },
                new Category
                {
                    categoryId = 8,
                    categoryName = "Television"
                },
                new Category
                {
                    categoryId = 9,
                    categoryName = "VHS"
                }
                );

            mb.Entity<Movies>().HasData(
                new Movies
                {
                    movieId = 1,
                    categoryId = 1,
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
                    movieId = 2,
                    categoryId = 7,
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
                    movieId = 3,
                    categoryId = 7,
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
