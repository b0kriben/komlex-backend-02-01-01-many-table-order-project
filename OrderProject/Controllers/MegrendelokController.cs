using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MegrendelokController : ControllerBase
    {
        private readonly CsvDb13Context _csvDb13Context = new();
        private readonly CsvDb12Context _csvDb12Context = new();

        // 1.4 Számold meg, hány különböző megrendelő van az adatbázisban! 
        [HttpGet("MegrendelokCount")]
        public async Task<IActionResult> GetMegrendelokCountAsync()
        {
            return Ok(await _csvDb13Context.Megrendeloks.CountAsync());
        }

        // 2.2 Számold meg, hány megrendelő lakik Budapesten! 
        [HttpGet("Budapest")]
        public async Task<IActionResult> GetBudapestAsync()
        {
            return Ok(await _csvDb13Context.Megrendeloks.CountAsync(m => m.Lakhely == "Budapest"));
        }

        // 3.3 Listázd ki az összes megrendelőt, akik férfiak! 
        [HttpGet("Ferfiak")]
        public async Task<IActionResult> GetFerfiaksync()
        {
            return Ok(await _csvDb13Context.Megrendeloks.OrderBy(m => m.Ferfi == "True").ToListAsync());
        }

        // 3.7 Listázd ki az összes rendelést és rendezd azokat lakhely szerint! 
        [HttpGet("MegrendelesekByLakhely")]
        public async Task<IActionResult> GetMegrendelesekByLakhelyCountAsync()
        {
            var query = from megrendelo in _csvDb13Context.Megrendeloks
                        from megrendeles in _csvDb12Context.Megrendeleseks
                        orderby megrendelo.Lakhely
                        where megrendeles.MegrendeloId == megrendelo.Id
                        select megrendelo;
            List<Megrendelok> result = await query.ToListAsync();
            return Ok(result);
        }
    }
}

