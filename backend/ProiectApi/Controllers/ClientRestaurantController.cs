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
    public class ClientRestaurantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientRestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.ClientRestaurants.GetAll());
        }

        [HttpPost("body")]
        public IActionResult AddClientRestaurant(ClientRestaurant cr)
        {
            _unitOfWork.ClientRestaurants.Add(cr);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("count_clients/{id}")]
        public IActionResult getCountClients(int id)
        {
            var q = _unitOfWork.ClientRestaurants.GetAll().Where(x => x.IdRestaurant == id).GroupBy(x => x.IdRestaurant);
            Console.WriteLine(q);
            return Ok(q.Select(x => x.Count()).FirstOrDefault());
        }

        [HttpDelete("{id1}/{id2}")]
        public IActionResult DeleteClientRestaurant(int id1, int id2)
        {
            ClientRestaurant client_restaurant = _unitOfWork.ClientRestaurants.GetByIds(id1, id2);
            _unitOfWork.ClientRestaurants.Remove(client_restaurant);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}