using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop_DW.Common.Models
{
    public class MovieTicket
    {
        private readonly int rowNr;
        private readonly int seatNr;
        private readonly bool isPremium;
        private readonly MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNumber)
        {
            this.movieScreening = movieScreening;
            isPremium = isPremiumReservation;
            rowNr = seatRow;
            seatNr = seatNumber;
        }

        public bool IsPremiumTicket()
        {
            return isPremium;
        }

        public double GetPrice(bool isStudentOrder)
        {
            return 0;
        }

        public override string ToString()
        {
            return $"Movie: {movieScreening}, Seat: {rowNr}-{seatNr}, Premium: {isPremium}";
        }
    }

}
