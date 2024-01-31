// Example usage
using Bioscoop_DW.Common.Enums;
using Bioscoop_DW.Common.Models;

Movie movie = new Movie("Inception");
MovieScreening screening = new MovieScreening(movie, DateTime.Now, 10.0);
MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1);
MovieTicket ticket2 = new MovieTicket(screening, true, 1, 2);
MovieTicket ticket3 = new MovieTicket(screening, true, 1, 3);


Order order = new Order(1, false);
order.AddSeatReservation(ticket1);
order.AddSeatReservation(ticket2);
order.AddSeatReservation(ticket3);


Console.WriteLine("Order Details:");
Console.WriteLine(order);

Console.WriteLine("Total Price: $" + order.CalculatePrice());

// Export to plain text and JSON
order.Export(TicketExportFormat.PLAINTEXT, "order_plain.txt");
order.Export(TicketExportFormat.JSON, "order_json.json");