using Bioscoop_DW.Common.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            double totalPrice = 0;

            for (int i = 0; i < seatReservations.Count; i++)
            {
                MovieTicket ticket = seatReservations[i];

                // Regel: Elk 2e ticket is gratis voor studenten, elke dag van de week
                if (isStudentOrder && i % 2 == 1)
                {
                    continue; // Skip het tweede ticket voor studenten
                }

                // Regel: Elk 2e ticket is gratis voor iedereen op doordeweekse dagen
                if (i % 2 == 1 && ticket.MovieScreening.IsWeekday())
                {
                    continue; // Skip het tweede ticket op doordeweekse dagen
                }

                // Regel: In het weekend krijgen groepen van 6 of meer 10% korting
                if (!isStudentOrder && ticket.MovieScreening.IsWeekend() && seatReservations.Count >= 6)
                {
                    totalPrice += 0.9 * ticket.GetPrice(isStudentOrder);
                }
                else
                {
                    totalPrice += ticket.GetPrice(isStudentOrder);
                }
            }

            return totalPrice;
        }

        public void Export(TicketExportFormat exportFormat, string fileName)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    ExportToPlainText(fileName);
                    break;
                case TicketExportFormat.JSON:
                    ExportToJson(fileName);
                    break;
                default:
                    throw new ArgumentException("Invalid export format");
            }
        }

        private void ExportToPlainText(string fileName)
        {
            // Specify the name of the folder within the project
            string folderName = "ExportedFiles";

            // Get the root directory of the project
            string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

            // Combine the project root directory with the desired folder name
            string folderPath = Path.Combine(projectRoot, "Bioscoo_DW.Console", folderName);

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Combine the folder path with the file name
            string filePath = Path.Combine(folderPath, fileName);

            // Write the content to the file
            File.WriteAllText(filePath, GeneratePlainTextContent());
        }

        private string GeneratePlainTextContent()
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine("Order Details:");
            content.AppendLine($"Order Number: {orderNr}");
            content.AppendLine($"Is Student Order: {isStudentOrder}");

            foreach (var ticket in seatReservations)
            {
                content.AppendLine($"Ticket: {ticket}");
                // Include MovieScreening details
                content.AppendLine($"  - Movie Title: {ticket.MovieScreening.Movie.Title}");
                content.AppendLine($"  - Date and Time: {ticket.MovieScreening.DateAndTime}");
            }

            content.AppendLine($"Total Price: ${CalculatePrice()}");

            return content.ToString();
        }


        private void ExportToJson(string fileName)
        {
            try
            {
                // Specify the name of the folder within the project
                string folderName = "ExportedFiles";

                // Get the root directory of the project
                string projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../"));

                // Combine the project root directory with the desired folder name
                string folderPath = Path.Combine(projectRoot, "Bioscoo_DW.Console", folderName);

                // Create the folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Combine the folder path with the specified file name
                string fullPath = Path.Combine(folderPath, fileName);

                var jsonData = new
                {
                    OrderDetails = new
                    {
                        OrderNumber = orderNr,
                        IsStudentOrder = isStudentOrder,
                        Tickets = seatReservations.Select(ticket => new
                        {
                            MovieTitle = ticket.MovieScreening.Movie.Title,
                            DateAndTime = ticket.MovieScreening.DateAndTime,
                            Seat = $"{ticket.RowNr}-{ticket.SeatNr}",
                            Premium = ticket.IsPremiumTicket(),
                            Price = ticket.GetPrice(isStudentOrder)
                        }),
                        TotalPrice = CalculatePrice()
                    }
                };

                // Serialize and write to the file
                string json = JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);
                Console.WriteLine($"Serialized JSON: {json}");

                File.WriteAllText(fullPath, json);

                Console.WriteLine($"Order exported to JSON file: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting order to JSON: {ex.Message}");
            }
        }





        public override string ToString()
            {
                return $"Order Number: {orderNr}, Is Student Order: {isStudentOrder}, Tickets: {string.Join(", ", seatReservations)}";
            }
        }

    }

