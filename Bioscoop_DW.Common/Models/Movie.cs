using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_DW.Common.Models
{
    public class Movie
    {
        private readonly string Title;

        public Movie(string title)
        {
            Title = title;
        }

        public void addScreening(MovieScreening screening)
        {

        }
        public override string ToString()
        {
            return Title;
        }
    }
}
