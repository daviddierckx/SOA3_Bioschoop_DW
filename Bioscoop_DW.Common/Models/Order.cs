using Bioscoop_DW.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bioscoop_DW.Common.Models
{
    public class Order
    {  
            private readonly int orderNr;
            private readonly bool isStudentOrder;
            private readonly List<MovieTicket> seatReservations;

            public Order(int orderNr, bool isStudentOrder)
            {
                this.orderNr = orderNr;
                this.isStudentOrder = isStudentOrder;
                seatReservations = new List<MovieTicket>();
            }

            public int GetOrderNr()
            {
                return orderNr;
            }

            public void AddSeatReservation(MovieTicket ticket)
            {
                seatReservations.Add(ticket);
            }

            public double CalculatePrice()
            {
                return 0;
            }

            public void Export(TicketExportFormat exportFormat, string fileName)
            {
               
            }

           

            public override string ToString()
            {
                return $"Order Number: {orderNr}, Is Student Order: {isStudentOrder}, Tickets: {string.Join(", ", seatReservations)}";
            }
        }

    }

