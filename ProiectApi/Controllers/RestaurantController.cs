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
    public class RestaurantController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Restaurants.GetAll());
        }
        public IActionResult GetPopularRestaurants([FromQuery] int count)
        {
            return Ok(_unitOfWork.Restaurants.GetTopRestaurants(count));

        }
        [HttpPost]
        public IActionResult AddRestaurant()
        {
            var restaurant = new Restaurant
            {
                Name = "Taj",
                Description = "Cel mai bun restaurant din oras",
                Rating = 5
            };
            _unitOfWork.Restaurants.Add(restaurant);
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpPost("body")]
        public IActionResult AddRestaurant(Restaurant r)
        {   
            _unitOfWork.Restaurants.Add(r);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getRestaurantById(int id)
        {
            return Ok(_unitOfWork.Restaurants.GetById(id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = _unitOfWork.Restaurants.GetById(id);
            _unitOfWork.Restaurants.Remove(restaurant);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}