using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeszallitokController : ControllerBase
    {
        private readonly CsvDb10Context _csvDb10Context = new();

        // 1.2 Számold meg, hány beszállító van az adatbázisban! 
        [HttpGet("BeszallitokCount")]
        public async Task<IActionResult> GetBeszallitokCountAsync()
        {
            return Ok(await _csvDb10Context.Beszallitoks.CountAsync());
        }

        // 2.4 Számold meg, hány különböző beszállító van, akik Debrecenből szállítanak! 
        [HttpGet("BeszallitokDebrecenCount")]
        public async Task<IActionResult> GetBeszallitokDebrecenCountAsync()
        {
            return Ok(await _csvDb10Context.Beszallitoks.CountAsync(b => b.BeszallitoTelephely == "Debrecen"));
        }

        // 3.2 Listázd ki az összes beszállítót név szerint növekvő sorrendben! 
        [HttpGet("BeszallitoNevSorrend")]
        public async Task<IActionResult> GetBeszallitoNevSorrendAsync()
        {
            return Ok(await _csvDb10Context.Beszallitoks.OrderBy(b => b.BeszallitoNev).ToListAsync());
        }
    }
}
