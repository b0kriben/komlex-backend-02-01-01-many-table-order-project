using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlkatreszekController : ControllerBase
    {
        private readonly CsvDb9Context _csvDb9Context = new();

        // 1.1 Számold meg, hány alkatrész található az adatbázisban! 
        [HttpGet("AlkatreszekCount")]
        public async Task<IActionResult> GetAlkatreszekCountAsync()
        {
            return Ok(await _csvDb9Context.Alkatreszeks.CountAsync());
        }

        // 2.1 Számold meg, hány laptop alkatrész található az adatbázisban! 
        [HttpGet("LaptopAlkatreszekCount")]
        public async Task<IActionResult> GetLaptopAlkatreszekCountAsync()
        {
            return Ok(await _csvDb9Context.Alkatreszeks.CountAsync(a => a.LaptopAlkatresz == "True"));
        }

        // 2.5 Számold meg, hány különböző alkatrész kategória található az adatbázisban! 
        [HttpGet("KulonbozoAlkatreszekCount")]
        public async Task<IActionResult> GetKulonbozoAlkatreszekCountAsync()
        {
            var kulonbozoAlkatreszek = await _csvDb9Context.Alkatreszeks
                .Select(a => a.Nev)
                .Distinct()
                .CountAsync();

            return Ok(kulonbozoAlkatreszek);
        }

        // 3.1 Listázd ki az összes alkatrészt! 
        [HttpGet("AlkatreszLista")]
        public async Task<IActionResult> GetAlkatreszListaAsync()
        {
            return Ok(await _csvDb9Context.Alkatreszeks.OrderBy(a => a.Nev).ToListAsync());
        }
    }
}
