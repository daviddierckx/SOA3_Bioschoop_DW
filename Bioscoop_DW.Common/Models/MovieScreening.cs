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

        public bool IsWeekday()
        {
            return dateAndTime.DayOfWeek >= DayOfWeek.Monday && dateAndTime.DayOfWeek <= DayOfWeek.Thursday;
        }

        public bool IsWeekend()
        {
            return dateAndTime.DayOfWeek == DayOfWeek.Friday || dateAndTime.DayOfWeek == DayOfWeek.Saturday ||
                   dateAndTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public double GetPricePerSeat()
        {
            return pricePerSeat;
        }


        public Movie Movie
        {
            get { return movie; }
        }

        public DateTime DateAndTime
        {
            get { return dateAndTime; }
        }

        public override string ToString()
        {
            return $"{movie}, {dateAndTime}";
        }
        
    }
}
