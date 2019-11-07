using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDataViewModel
    {
        public IEnumerable<Genre> genres { get; set; }

        public int? id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? genreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? releaseDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? numberInStock { get; set; }

        public MovieDataViewModel()
        {
            id = 0;
        }
        public MovieDataViewModel(Movies movie)
        {
            this.id = movie.id;
            this.genreId = movie.genreId;
            this.releaseDate = movie.releaseDate;
            this.numberInStock = movie.numberInStock;
        }
    }
}