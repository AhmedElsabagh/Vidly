using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int genreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Required]
        public DateTime dateAdded { get; set; }

        [Required]
        [Display(Name ="Number In Stock")]
        [Range(1,20)]
        public int numberInStock { get; set; }
    }
}