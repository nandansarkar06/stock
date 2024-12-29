using learning.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet("getStocks")]
        public ActionResult<IEnumerable<string>> GetStocks()
        {
            var stocks = _context.Stocks;
            return Ok(stocks);
        }
    }
}