using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samir_Cabrera.Movies.Entity
{
    public class Image
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Url { get; set; }
    }
}
