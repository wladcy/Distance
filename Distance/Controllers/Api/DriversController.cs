﻿using System;
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
    public class DriversController : ApiController
    {
        private ApplicationDbContext _context;

        public DriversController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/drivers
        public IHttpActionResult GetDrivers()
        {
            var driverDtos = _context.Users.ToList().Select(Mapper.Map<ApplicationUser, DriverDto>);

            return Ok(driverDtos);
        }

        // GET /api/drivers/1
        public IHttpActionResult GetDriver(string id)
        {
            var driver = _context.Users.SingleOrDefault(c => c.Id.Equals(id));

            if (driver == null)
                return NotFound();

            return Ok(Mapper.Map<ApplicationUser, DriverDto>(driver));
        }

        // POST /api/drivers
        [HttpPost]
        public IHttpActionResult CreateDriver(DriverDto driverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var driver = Mapper.Map<DriverDto, ApplicationUser>(driverDto);
            _context.Users.Add(driver);
            _context.SaveChanges();

            driverDto.Id = driver.Id;

            return Created(new Uri(Request.RequestUri + "/" + driver.Id), driverDto);
        }

        // PUT /api/drivers/1
        [HttpPut]
        public IHttpActionResult UpdateDriver(string id, DriverDto driverDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var driverInDb = _context.Users.SingleOrDefault(c => c.Id.Equals(id));

            if (driverInDb == null)
                return NotFound();

            Mapper.Map(driverDto, driverInDb);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/drivers/1
        [HttpDelete]
        public IHttpActionResult DeleteDriver(string id)
        {
            if (!IsAdministrator())
                return NotFound();
            var driverInDb = _context.Users.SingleOrDefault(c => c.Id.Equals(id));
            string userId = User.Identity.GetUserId();
            if (driverInDb == null || userId.Equals(id))
                return NotFound();

            _context.Users.Remove(driverInDb);
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
