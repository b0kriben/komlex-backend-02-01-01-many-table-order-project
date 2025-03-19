using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MegrendelesekController : ControllerBase
    {
        private readonly CsvDb12Context _csvDb12Context = new();

        // 1.3 Számold meg, hány rendelés érkezett be összesen! 
        [HttpGet("MegrendelsekCount")]
        public async Task<IActionResult> GetMegrendelsekCountAsync()
        {
            return Ok(await _csvDb12Context.Megrendeleseks.CountAsync());
        }

        // 2.3 Számold meg, hány olyan rendelés van, amely még nincs teljesítve! 
        [HttpGet("NincsTeljesitveCount")]
        public async Task<IActionResult> GetNincsTeljesitveCountAsync()
        {
            return Ok(await _csvDb12Context.Megrendeleseks.CountAsync(m => m.Teljesitve == "False"));
        }

        // 3.4 Listázd ki az összes rendelést dátum szerint csökkenő sorrendben! 
        [HttpGet("DatumCsokkeno")]
        public async Task<IActionResult> GetDatumCsokkenosync()
        {
            return Ok(await _csvDb12Context.Megrendeleseks.OrderByDescending(m => m.Datum).ToListAsync());
        }
    }
}
