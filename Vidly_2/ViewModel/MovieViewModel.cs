using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2.Models;

namespace Vidly_2.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<GenreModel> Genre{ get; set; }
        public MovieModel Movie { get; set; }
    }
}