using EntityFramoworkCore.Entities;

namespace EntityFramoworkCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext contex = new AirplaneDbContext();
            contex.Clients.Add(new Client()
            {
                Name = "Volodia",
                Birthday = new DateTime(2006, 12, 6),
                Email = "volodia@email.com"
            });
            contex.SaveChanges();
            foreach (var item in contex.Clients)
            {
                Console.WriteLine($"Client : name - {item.Name}. " +
                    $"Email: {item.Email}.Birthday : {item.Birthday?.ToShortDateString()}");
            }


            var filteredFlights = contex.Flights
                                        .Where(f => f.ArrivalCity == "Lviv")
                                        .OrderBy(f => f.DepartureCity);

            foreach (var f in filteredFlights)
            {
                Console.WriteLine($"Fligt : {f.Id}. From : {f.DepartureCity} to {f.ArrivalCity}" +
                    $"Date : {f.DepartureTime.ToShortDateString()}");
            }

            var client = contex.Clients.Find(1);

            if (client != null)
            {
                contex.Clients.Remove(client);
                contex.SaveChanges();
            }

            foreach (var f in contex.Flights)
            {
                Console.WriteLine($"Fligt : {f.Id} From {f.DepartureCity} {f.DepartureTime} ");
            }


        }
    }
}