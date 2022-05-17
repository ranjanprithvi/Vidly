using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
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

        // GET: Rentals
        public ActionResult New()
        {
            //var viewModel = new NewRentalViewModel();

            return View();
        }

        public ActionResult Create(NewRentalViewModel viewModel)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == viewModel.CustomerId);

            if (customerinDb != null)
            {
                foreach(var movieId in viewModel.MovieIds)
                {
                    var movieinDb = _context.Movies.SingleOrDefault(m => m.Id == movieId);
                    if(movieinDb != null)
                    {
                        _context.Rentals.Add(new Rental { Customer = customerinDb, Movie = movieinDb, DateRented = DateTime.Now });
                        //Show Movie rented Success Notification
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
                //Show Customer Failure Notification
            }

            //Clear out customer and movie fields
            return RedirectToAction("Index","Rentals");
        }
    }
}