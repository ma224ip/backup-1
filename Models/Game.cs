using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Cybergames.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [Url]
        public string? Cover { get; set; }

        [Url]
        public string? Img1 { get; set; }

        [Url]
        public string? Img2 { get; set; }

        [Url]
        public string? Img3 { get; set; }

        [Url]
        public string? Img4 { get; set; }

        [Url]
        public string? Img5 { get; set; }
    }
}