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
        public IActionResult GetPopularRestaurants([FromQuery] int count)
        {
            var popularDevelopers = _unitOfWork.Restaurants.GetTopRestaurants(count);
            return Ok(popularDevelopers);

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


        [HttpPost("fromForm")]
        public IActionResult AddWithFromForm([FromForm] Restaurant restaurant)
        {
            Console.WriteLine(restaurant);
            _unitOfWork.Restaurants.Add(restaurant);
            _unitOfWork.Complete();
            return Ok(restaurant);
        }
    }
}