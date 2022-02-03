using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int movieId { get; set; } //Primary Key        
        [Required(ErrorMessage = "Enter the movie title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Enter the movie year")]
        public int year { get; set; }
        [Required(ErrorMessage = "Enter the movie director")]
        public string director { get; set; }
        [Required(ErrorMessage = "Enter the movie rating")]
        public string rating { get; set; }
        [Required(ErrorMessage = "Has the movie been edited?")]
        public bool edited { get; set; }
        public string lentTo { get; set; }
        [MaxLength(25)]
        public string notes { get; set; }

        //Foreign Key relationship
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}
