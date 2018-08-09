using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Distance.Dtos;
using Distance.Models;
using Microsoft.AspNet.Identity;

namespace Distance.Controllers.Api
{
    [Authorize]
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
           _context = new ApplicationDbContext();
        }

        // GET /api/cars
        public IEnumerable<CarDto> GetCars()
        {
            return _context.Cars.ToList().Select(Mapper.Map<Cars, CarDto>);
        }

        // GET /api/cars/1
        public IHttpActionResult GetCars(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return NotFound();

            return Ok(Mapper.Map<Cars, CarDto>(car));
        }

        // POST /api/cars
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = Mapper.Map<CarDto, Cars>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;

            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }

        // PUT /api/cars/1
        [HttpPut]
        public IHttpActionResult UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return NotFound();

            Mapper.Map(carDto, carInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/cars/1
        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            
            if (!IsAdministrator())
                return NotFound();
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return NotFound();

            _context.Cars.Remove(carInDb);
            _context.SaveChanges();

            return Ok();
        }

        public bool IsAdministrator()
        {
            bool retval = false;
            var userId = User.Identity.GetUserId();
            DatabaseControler dc = new DatabaseControler();
            var user = dc.GetUserById(userId);
            if (dc.GetUserRoles(user).Contains("ADMINISTRATOR"))
            {
                retval = true;
            }
            return retval;
        }
    }
}
