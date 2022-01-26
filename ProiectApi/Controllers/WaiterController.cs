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

        [HttpGet("{id}")]
        public IActionResult getRestaurantById(int id)
        {
            return Ok(_unitOfWork.Restaurants.GetById(id));
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