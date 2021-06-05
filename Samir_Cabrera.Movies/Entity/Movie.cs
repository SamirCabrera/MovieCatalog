using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samir_Cabrera.Movies.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Boolean Like { get; set; }
        public Boolean View { get; set; }
        public Boolean ToViewLater { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
