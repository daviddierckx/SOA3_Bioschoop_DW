// See https://aka.ms/new-console-template for more information

using Bioscoop_DW.Common.Enums;
using Bioscoop_DW.Common.Models;

Console.WriteLine("Hello, World! ddd");

Order order = new(1, false);
order.Export(TicketExportFormat.JSON);