using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportationSystem.Data;
using TransportationSystem.DTOs.BusDTO;
using TransportationSystem.Models;
using AutoMapper;
namespace TransportationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BusController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Bus == get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.Buses.ToListAsync();
            var result = _mapper.Map<List<BusDto>>(items);
            return Ok(result);
        }
        // GET: by id == get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.Buses.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<BusDto>(item);
            return Ok(result);
        }
        // POST: api/Bus == create
        [HttpPost]
        public async Task<IActionResult> Add_Bus(BusCreateDto bus)
        {
            if (bus == null)
                return BadRequest("Invalid data");
            var newBus = _mapper.Map<Bus>(bus);
            _context.Buses.Add(newBus);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = newBus.Id }, newBus);
        }
        // PUT: api/Bus/{id} == update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update_Bus(int id, BusUpdateDto bus)
        {
            if (bus == null )
                return BadRequest("Invalid data");
            
            var existingBus = await _context.Buses.FindAsync(id);
            if (existingBus == null)
            {
                return NotFound();
            }
            
            _mapper.Map(bus, existingBus);
            _context.Buses.Update(existingBus);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
