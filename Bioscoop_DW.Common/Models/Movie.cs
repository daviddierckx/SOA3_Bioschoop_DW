using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_DW.Common.Models
{
    public class Movie
    {
        private readonly string title;

        public Movie(string title)
        {
            this.title = title;
        }

        public void addScreening(MovieScreening screening)
        {

        }

        public string Title
        {
            get { return title; }
        }

        public override string ToString()
        {
            return title;
        }
    }
}
