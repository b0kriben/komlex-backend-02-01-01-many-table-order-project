using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly OrderContext _orderContext = new OrderContext();

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _orderContext.Customers.ToListAsync());
        }
    }
}
