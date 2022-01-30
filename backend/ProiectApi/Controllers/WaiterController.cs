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
    public class WaiterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public WaiterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("restaurants")]
        public IActionResult GetWaiters()
        {
            return Ok(_unitOfWork.Waiters.GetRestaurantWaiters());
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Waiters.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult getRestaurantById(int id)
        {
            return Ok(_unitOfWork.Restaurants.GetById(id));
        }

        [HttpGet("restaurant_by_waiter_id/{id}")]
        public IActionResult getRestaurantNamebyWaiterId(int id)
        {
            var restaurant_name = _unitOfWork.Waiters.GetAll().Where(x => x.Id == id).Join(_unitOfWork.Restaurants.GetAll(),
                x => x.RestaurantId, y => y.Id,
                (x, y) =>
                y.Name
            );
            return Ok(restaurant_name.FirstOrDefault());
        }

        [HttpGet("waiter_infos")]
        public IActionResult GetWaiterInfo()
        {
            return Ok(_unitOfWork.Waiters.getWaiterInfos());
        }

        [HttpPost("body")]
        public IActionResult AddWaiter(Waiter w)
        {
            _unitOfWork.Waiters.Add(w);
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult updateRestaurant(Waiter w, int id)
        {
            Waiter waiter = _unitOfWork.Waiters.GetById(id);
            waiter.First_Name = w.First_Name;
            waiter.Last_Name = w.Last_Name;
            waiter.RestaurantId = w.RestaurantId;
            _unitOfWork.Complete();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWaiter(int id)
        {
            Waiter waiter = _unitOfWork.Waiters.GetById(id);
            _unitOfWork.Waiters.Remove(waiter);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}