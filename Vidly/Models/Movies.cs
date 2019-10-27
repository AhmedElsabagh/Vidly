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

        [Required]
        public Genre genre { get; set; }
        public int genreId { get; set; }
        [Required]
        public DateTime releaseDate { get; set; }
        [Required]
        public DateTime dateAdded { get; set; }
        [Required]
        public int numberInStock { get; set; }
    }
}