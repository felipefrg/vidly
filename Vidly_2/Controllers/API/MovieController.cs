using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly_2.Models;
using Vidly_2.Models.DTO;

namespace Vidly_2.Controllers.API
{
    public class MovieController : ApiController
    {
        ApplicationDbContext _dbContext;

        public MovieController()
        {
            this._dbContext = new ApplicationDbContext();
        }

        // GET api/<controller>
        public IEnumerable<MovieModelDTO> Get()
        {
            return _dbContext.Movie.ToList().Select(Mapper.Map<MovieModel, MovieModelDTO>);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var movie = _dbContext.Movie.SingleOrDefault(m => m.Id == id);
            if(movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MovieModel,MovieModelDTO>(movie));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(MovieModelDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieModelDTO, MovieModel>(movieDTO);
            _dbContext.Movie.Add(movie);
            _dbContext.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
            
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, MovieModelDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _dbContext.Movie.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map<MovieModelDTO, MovieModel>(movieDTO, movie);

            _dbContext.SaveChanges();

            return Ok(movieDTO);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var movie = _dbContext.Movie.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movie.Remove(movie);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}