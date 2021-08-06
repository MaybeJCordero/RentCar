using CarCore.Entities;
using CarCore.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public CarController(ICarRepository repository, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cars = await _repository.GetAll();
                return Ok(cars);
            }
            catch (Exception)
            {
                //Log error
                return BadRequest("An error ocurred, contact IT Staff");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Car car)
        {
            try
            {
                var response = await _repository.Add(car);
                if (response != 0)
                {
                    return Ok("Added successfully");
                }
                else
                {
                    return BadRequest("An error ocurred, contact IT Staff");
                }

            }
            catch (Exception)
            {
                return BadRequest("An error ocurred, contact IT Staff");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Car car)
        {
            try
            {
                var response = await _repository.Update(car);
                if (response != 0)
                {
                    //Sending the object to the State Machine
                    await _publishEndpoint.Publish<Car>(car);

                    return Ok("Updated successfully");
                }
                else
                {
                    return BadRequest("An error ocurred, contact IT Staff");
                }
            }
            catch (Exception)
            {
                return BadRequest("An error ocurred, contact IT Staff");
            }
        }
    }
}
