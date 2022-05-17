using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public IHttpActionResult GetMovies(string query = null)
        {
            var movies = _context.Movies
                .Include(c => c.Genre);
            
            if (!string.IsNullOrWhiteSpace(query))
            {
                movies = movies.Where(c => c.Name.Contains(query) && c.NumberAvailable > 0);
            }

            return Ok(movies
                    .ToList()
                    .Select(Mapper.Map<Movie, MovieDTO>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movieinDb = _context.Movies.Single(m => m.Id == id);

            if (movieinDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDTO>(movieinDb));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null)
                NotFound();

            Mapper.Map(movieDto, movieInDB);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        //[Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null)
                NotFound();

            _context.Movies.Remove(movieInDB);
            _context.SaveChanges();

            return Ok();
        }

    }
}
