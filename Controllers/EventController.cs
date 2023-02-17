using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsEventProject.Models;

namespace SportsEventProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly SportsEventManagementContext db;
        public EventController(SportsEventManagementContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            return Ok(await db.Events.ToListAsync());

        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(Event e)
        {
            db.Events.Add(e);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            Event e = db.Events.Find(id);
            db.Events.Remove(e);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        [Route("EventByName")]
        public async Task<ActionResult<Event>> GetEventByName(string name)
        {
            Event e = await db.Events.SingleOrDefaultAsync(x=>x.EventName==name);
            return Ok(e);
        }
    }
}
