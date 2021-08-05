using ClientCore.Entities;
using ClientCore.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public ClientController(IClientRepository repository, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _repository.GetAll();
                return Ok(clients);
            }
            catch (Exception)
            {
                return BadRequest("An error ocurred, contact IT Staff");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client client)
        {
            try
            {
                var response = await _repository.Add(client);
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
        public async Task<IActionResult> Put(Client client)
        {
            try
            {
                var response = await _repository.Update(client);
                if (response != 0)
                {
                    //Sending the object to the client exchange
                    //await _publishEndpoint.Publish<Client>(client);

                    return Ok("Updated successfully");
                }
                else
                {
                    return BadRequest("An error ocurred, contact IT Staff");
                }
            }
            catch (Exception e)
            {
                return BadRequest("An error ocurred, contact IT Staff");
            }
        }
    }
}