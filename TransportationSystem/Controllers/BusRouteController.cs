using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TransportationSystem.Data;
using TransportationSystem.DTOs.BusRouteDTO;
using TransportationSystem.Models;

namespace TransportationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BusRouteController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/BusRoute
        [HttpGet]
        public async Task<IActionResult> GetBusRoutes()
        {
            var busRoutes = await _context.BusRoutes.ToListAsync();
            if (busRoutes == null || !busRoutes.Any())
            {
                return NotFound("No bus routes found.");
            }
            return Ok(busRoutes);
        }
        // GET: api/BusRoute/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusRouteById(int id)
        {
            var busRoute = await _context.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return NotFound($"Bus route with ID {id} not found.");
            }
            var result = _mapper.Map<BusRouteDto>(busRoute);
            return Ok(result);
        }
        // POST: api/BusRoute
        [HttpPost]
        public async Task<IActionResult> CreateBusRoute([FromBody] BusRouteCreateDto busRoute)
        {
            if (busRoute == null)
            {
                return BadRequest("Bus route data is null.");
            }
            var route = _mapper.Map<BusRoute>(busRoute);
            _context.BusRoutes.Add(route);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<BusRouteDto>(route);
            return CreatedAtAction(nameof(GetBusRouteById), new { id = route.Id }, result);
        }
        // PUT: api/BusRoute/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusRoute(int id, [FromBody] BusRouteUpdateDto busRoute)
        {
            if (busRoute == null)
            {
                return BadRequest("Bus route data is null.");
            }
            var existingRoute = await _context.BusRoutes.FindAsync(id);
            if (existingRoute == null)
            {
                return NotFound($"Bus route with ID {id} not found.");
            }
            _mapper.Map(busRoute, existingRoute);
            _context.BusRoutes.Update(existingRoute);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<BusRouteDto>(existingRoute);
            return Ok(result);
        }
        // DELETE: api/BusRoute/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusRoute(int id)
        {
            var busRoute = await _context.BusRoutes.FindAsync(id);
            if (busRoute == null)
            {
                return NotFound($"Bus route with ID {id} not found.");
            }
            _context.BusRoutes.Remove(busRoute);
            await _context.SaveChangesAsync();
            return NoContent(); // 204 No Content
        }
        // Search: api/BusRoute/search/{name}
        [HttpGet("search/{name}")]
        public  async Task<IActionResult> SearchBusRoutes(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term cannot be empty.");
            }
            var busRoutes = await _context.BusRoutes
                .Where(br => EF.Functions.Like(br.RouteName, $"%{name}%"))
                .ToListAsync();
            if (busRoutes == null || !busRoutes.Any())
            {
                return NotFound($"No bus routes found matching '{name}'.");
            }
            return Ok(busRoutes);
        }
    }
}
