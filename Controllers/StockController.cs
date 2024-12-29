using learning.Data;
using learning.Mappers;
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
            var stocks = _context.Stocks.ToList()
            .Select(s=> s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {   
            var stock = _context.Stocks.Find(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }
    }
}