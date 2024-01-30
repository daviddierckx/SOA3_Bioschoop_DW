using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_DW.Common.Models
{
   public class MovieScreening
    {
        private readonly Movie movie;
        private readonly DateTime dateAndTime;
        private readonly double pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this.movie = movie;
            this.dateAndTime = dateAndTime;
            this.pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return pricePerSeat;
        }

        public override string ToString()
        {
            return $"{movie.ToString}, {dateAndTime}";
        }
        
    }
}
