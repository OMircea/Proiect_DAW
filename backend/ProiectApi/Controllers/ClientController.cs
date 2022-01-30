using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Clients.GetAll());
        }
         
        [HttpPost("body")]
        public IActionResult AddClient(Client c)
        {
            _unitOfWork.Clients.Add(c);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult updateClient(Client c, int id)
        {
            Client client = _unitOfWork.Clients.GetById(id);
            client.Name = c.Name;
            client.Occupation = c.Occupation;
            client.Age = c.Age;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getClientById(int id)
        {
            return Ok(_unitOfWork.Clients.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            Client client = _unitOfWork.Clients.GetById(id);
            _unitOfWork.Clients.Remove(client);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}