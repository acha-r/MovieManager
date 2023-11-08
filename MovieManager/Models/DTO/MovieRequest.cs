using MovieManager.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Models.DTO
{
    public class MovieRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required]
        [Range(100, 10000, ErrorMessage = "Ticket price must be more than N100")]
        public double TicketPrice { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public IList<string> Genre { get; set; }

        [Required]
        public string PhotoUrl { get; set; }
    }

    public class UpdateMovieRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required]
        public IList<string> Genre { get; set; }
    }
}
