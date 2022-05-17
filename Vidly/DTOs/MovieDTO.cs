using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreDTO Genre { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }
    }
}