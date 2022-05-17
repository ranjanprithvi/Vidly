using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext _context;
        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalsDTO newRental)
        {
            var customerinDb = _context.Customers.Single(c => c.Id == newRental.customerID);

            if (customerinDb != null)
            {
                foreach (var movieId in newRental.movieIDs)
                {
                    var movieinDb = _context.Movies.SingleOrDefault(m => m.Id == movieId);
                    if (movieinDb != null)
                    {
                        if (movieinDb.NumberAvailable > 0)
                        {
                            _context.Rentals.Add(new Rental { Customer = customerinDb, Movie = movieinDb, DateRented = DateTime.Now });
                            movieinDb.NumberAvailable--;
                            //Show Movie rented Success Notification
                        }
                        else
                        {
                            //Show Movie not available notification
                        }
                    }
                    else
                    {
                        //Show Movie rented Failure Notification
                    }
                }
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
                //Show Customer Failure Notification
            }

            //Clear out customer and movie fields
            return Ok();
        }
    }
}
