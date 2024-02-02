using Bioscoop_DW.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioschoop_DW.Test
{
    public class OrderTests
    {
        [Fact]
        public void CalculatePrice_NoInput_EmptyOrder()
        {
            // Arrange
            Order emptyOrder = new Order(1, false); // You may need to adjust the constructor based on your actual implementation

            // Act
            double totalPrice = emptyOrder.CalculatePrice();

            // Assert
            Assert.Equal(0, totalPrice);
        }

        [Fact]
        public void CalculatePrice_SixTickets_TwoPremium_NotStudent_Weekend()
        {
            // Arrange
            // Create an order with two tickets, not for students, and on a weekday
            // You may need to adjust the constructor based on your actual implementation
            Movie movie = new Movie("Inception");
            MovieScreening screening = new MovieScreening(movie, new DateTime(2024, 2, 4), 10.0);
            MovieTicket ticket1 = new MovieTicket(screening, true, 1, 1);
            MovieTicket ticket2 = new MovieTicket(screening, true, 1, 2);
            MovieTicket ticket3 = new MovieTicket(screening, false, 1, 3);
            MovieTicket ticket4 = new MovieTicket(screening, false, 1, 4);
            MovieTicket ticket5 = new MovieTicket(screening, false, 1, 5);
            MovieTicket ticket6 = new MovieTicket(screening, false, 1, 6);

            Order order = new Order(1, false);
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);


            // Act
            double totalPrice = order.CalculatePrice(); // TODO afronden op 2 decimaal

            // Assert
            // Implement your expected total price based on the provided rules
            Assert.Equal(59.40, totalPrice);
        }

        [Fact]
        public void CalculatePrice_TwoTickets_NotStudent_Weekday()
        {
            // Arrange
            // Create an order with two tickets, not for students, and on a weekday
            // You may need to adjust the constructor based on your actual implementation
            Movie movie = new Movie("Inception");
            MovieScreening screening = new MovieScreening(movie, new DateTime(2024,2,1), 10.0);
            MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1);
            MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2);
            Order order = new Order(2, false);
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            // Implement your expected total price based on the provided rules
            Assert.Equal(10, totalPrice);
        }

        [Fact]
        public void CalculatePrice_TwoTickets_NotStudent_Weekend()
        {
            // Arrange
            // Create an order with two tickets, not for students, and on a weekend
            // You may need to adjust the constructor based on your actual implementation
            Movie movie = new Movie("Inception");
            MovieScreening screening = new MovieScreening(movie, new DateTime(2024, 2, 4), 10.0);
            MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1);
            MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2);
            Order order = new Order(3, false);
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            // Implement your expected total price based on the provided rules
            Assert.Equal(20, totalPrice);
        }


        [Fact]
        public void CalculatePrice_SevenTickets_TwoPremium_Student_Weekend()
        {
            // Arrange
            // Create an order with two tickets, not for students, and on a weekday
            // You may need to adjust the constructor based on your actual implementation
            Movie movie = new Movie("Inception");
            MovieScreening screening = new MovieScreening(movie, new DateTime(2024, 2, 4), 10.0);
            MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1);
            MovieTicket ticket2 = new MovieTicket(screening, false, 1, 2);
            MovieTicket ticket3 = new MovieTicket(screening, false, 1, 3);
            MovieTicket ticket4 = new MovieTicket(screening, false, 1, 4);
            MovieTicket ticket5 = new MovieTicket(screening, false, 1, 5);
            MovieTicket ticket6 = new MovieTicket(screening, false, 1, 6);
            MovieTicket ticket7 = new MovieTicket(screening, false, 1, 7);


            Order order = new Order(4, true);
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);
            order.AddSeatReservation(ticket7);



            // Act
            double totalPrice = order.CalculatePrice();

            // Assert
            // Implement your expected total price based on the provided rules
            Assert.Equal( 40, totalPrice);
        }

    }
}
