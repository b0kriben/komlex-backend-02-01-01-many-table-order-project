using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly OrderContext _orderContext = new();

        // Termékek száma
        [HttpGet("ProductCount")]
        public async Task<IActionResult> GetProductCountAsync()
        {
            return Ok(await _orderContext.Products.CountAsync());
        }

        // Adott összegnél drágább termékek száma
        [HttpGet("ExpensiveProductsCount/{price}")]
        public async Task<IActionResult> ExpensiveProductsCountAsync(int price)
        {
            return Ok(await _orderContext.Products.Where(p => p.Price > price).CountAsync());
        }

        // Adott összegnél drágább termékek
        [HttpGet("ExpensiveProducts/{price}")]
        public async Task<IActionResult> ExpensiveProductsAsync(int price)
        {
            return Ok(await _orderContext.Products.Where(p => p.Price > price).ToListAsync());
        }

        // Szűrés a vásárló emailcím végére illetve a keretösszeg nagyságára
        [HttpGet("filter")]
        public async Task<IActionResult> FilterAsync([FromQuery] string emailEnds, [FromQuery] int minBudget)
        {
            return Ok(await _orderContext.Customers.Where(c =>
                    c.Email.EndsWith(emailEnds) &&
                    c.Budget >= minBudget
                ).ToListAsync());
        }

        // Összetett szűrés
        [HttpPost("filter2")]
        public async Task<IActionResult> Filter2Async([FromBody] CustomerQuery customerQuery)
        {
            return Ok(await _orderContext.Customers.Where(c =>
                    c.Email.Contains(customerQuery.Email) &&
                    c.Budget >= customerQuery.Budget &&
                    c.Name.Contains(customerQuery.Name)
                ).ToListAsync());
        }

        // Összes kategória névsorrendben
        [HttpGet("CategorySorted")]
        public async Task<IActionResult> GetCategorySortedAsync()
        {
            return Ok(await _orderContext.Categories.OrderBy(c => c.CategoryName).ToListAsync());
        }

        // Összes kategória névsorrendben fordítva
        [HttpGet("CategorySortedReverse")]
        public async Task<IActionResult> GetCategorySortedReverseAsync()
        {
            return Ok(await _orderContext.Categories.OrderByDescending(c => c.CategoryName).ToListAsync());
        }
    }
}
