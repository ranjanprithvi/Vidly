using System.Collections.Generic;

namespace Vidly.DTOs
{
    public class RentalsDTO
    {
        public int customerID { get; set; }
        public List<int> movieIDs { get; set; }
    }
}