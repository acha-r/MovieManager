using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace MovieManager.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }
        public double TicketPrice { get; set; }
        public string Country { get; set; }
        public IList<string> Genre { get; set; }
        public string PhotoUrl { get; set; }
    }
}