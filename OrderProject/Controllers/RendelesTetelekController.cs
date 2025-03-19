using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesTetelekController : ControllerBase
    {
        private readonly CsvDb14Context _csvDb14Context = new();

        // 1.5 Számold meg, hány rendelés lett teljesítve!
        [HttpGet("RendelesTeljesitveCount")]
        public async Task<IActionResult> GetRendelesTeljesitveCountAsync()
        {
            return Ok(await _csvDb14Context.RendelesTeteleks.CountAsync());
        }
    }
}
