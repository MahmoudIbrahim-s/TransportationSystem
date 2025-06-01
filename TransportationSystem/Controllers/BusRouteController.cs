using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportationSystem.Data;

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
    }
}
