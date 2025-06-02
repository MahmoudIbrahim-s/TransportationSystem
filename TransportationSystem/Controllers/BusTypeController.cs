using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportationSystem.Data;
using TransportationSystem.Models;
using TransportationSystem.DTOs.BusTypeDTO;
using AutoMapper;


namespace TransportationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTypeController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BusTypeController(ApplicationDbContext context ,IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }
        

        // GET: api/BusType == get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.BusTypes.ToListAsync();
            var result = _mapper.Map<List<BusTypeDto>>(items);
            return Ok(result);
        }
        // GET: by id == get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.BusTypes.FindAsync(id);
            var result = _mapper.Map<BusTypeDto>(item);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // POST: api/BusType == create
        [HttpPost]
        public async Task<IActionResult> Add_BusType(BusTypeCreateDto busType)
        {
            if (busType == null)
                return BadRequest("Invalid data");

            var newBusType = _mapper.Map<BusType>(busType);
            _context.BusTypes.Add(newBusType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newBusType.Id }, newBusType);
        }
        // PUT: api/BusType/{id} == update  

        [HttpPut("{id}")]
        public async Task<IActionResult> Update_Bus(int id, BusTypeUpdateDto busType)
        {var existingBusType = await _context.BusTypes.FindAsync(id);

            if (existingBusType == null)
            {
                return NotFound();
            }

            existingBusType.Name = busType.Name;
            existingBusType.Description = busType.Description;
            existingBusType.Category = busType.Category;
            _context.Entry(existingBusType).State = EntityState.Modified;
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
