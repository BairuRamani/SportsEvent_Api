using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEventProject.Models;

namespace SportsEventProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly SportsEventManagementContext db;
        public SportController(SportsEventManagementContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public async Task<ActionResult> GetSportss()
        {
            return Ok(await db.Sports.ToListAsync());

        }

        [HttpGet]
        [Route("SportByName")]
        public async Task<ActionResult<Event>> GetSportByName(string name)
        {
            Sport s = await db.Sports.SingleOrDefaultAsync(x => x.SportsName == name);
            return Ok(s);
        }
    }
}