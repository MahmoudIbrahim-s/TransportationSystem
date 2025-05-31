using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportationSystem.Data;
using TransportationSystem.Models;

namespace TransportationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTypeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public BusTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public async Task<ActionResult<List<BusType>>> GetAll()
        //{
        //    var items = new List<BusType> 
        //    {
        //        new BusType
        //        {
        //            Id = 1,
        //            Name = "City Bus"
        //        }
        //    };
        //    return Ok(items);
        //}


        // GET: api/BusType == get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.BusTypes.ToListAsync();
            return Ok(items);
        }
        // GET: by id == get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.BusTypes.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // POST: api/BusType == create
        [HttpPost]
        public async Task<IActionResult> Add_Bus(BusType busType)
        {
            if (busType == null)
            {
                return BadRequest("BusType cannot be null.");
            }
            _context.BusTypes.Add(busType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = busType.Id }, busType);
        }
        // PUT: api/BusType/{id} == update  

        [HttpPut("{id}")]
        public async Task<IActionResult> Update_Bus(int id, BusType busType)
        {
            if (id != busType.Id)
            {
                return BadRequest("BusType ID don`t match.");
            }
            var existingBus = await _context.BusTypes.FindAsync(id);
            if (existingBus == null)
            {
                return NotFound();
            }
            existingBus.Name = busType.Name;
            existingBus.Description = busType.Description;
            _context.Entry(existingBus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(await _context.BusTypes.FindAsync(id));
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete_Bus(int id)
        {
            var busType = await _context.BusTypes.FindAsync(id);
            if (busType == null)
            {
                return NotFound();
            }
            _context.BusTypes.Remove(busType);
            await _context.SaveChangesAsync();
            return Ok(await _context.BusTypes.ToListAsync());
        }

        // search by name
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be null or empty.");
            }
            var items = await _context.BusTypes
                .Where(b => EF.Functions.Like(b.Name, $"%{name}%"))
                .ToListAsync();
            if (items.Count == 0)
            {
                return NotFound("No bus types found with the specified name.");
            }
            return Ok(items);
        }

        // search by id
        [HttpGet("search/id/{id}")]
        public async Task<IActionResult> SearchById(int id)
        {
            var item = await _context.BusTypes.FindAsync(id);
            if (item == null)
            {
                return NotFound("No bus type found with the specified ID.");
            }
            return Ok(item);
        }
    }
}
