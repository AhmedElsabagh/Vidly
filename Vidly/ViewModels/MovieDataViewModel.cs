using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDataViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public Movies movie { get; set; }
    }
}