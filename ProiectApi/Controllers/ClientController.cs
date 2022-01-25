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

        [HttpPost]
        public IActionResult AddClient()
        {
            var client = new Client
            {
                Name = "Andrei Popescu",
                Occupation = "dsfsdf",
                Age = 5
            };
            _unitOfWork.Clients.Add(client);
            _unitOfWork.Complete();
            return Ok();
        }
         
        [HttpPost("body")]
        public IActionResult AddClient(Client c)
        {
            _unitOfWork.Clients.Add(c);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getClientById(int id)
        {
            return Ok(_unitOfWork.Clients.GetById(id));
        }
    }
}