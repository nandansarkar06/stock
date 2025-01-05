using learning.Data;
using learning.Dtos.Stock;
using learning.Interfaces;
using learning.Mappers;
using learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDBContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet("GetAllStocks")]
        public async Task<IActionResult> GetStocks()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var StockDto = stocks.Select(s=> s.ToStockDto());

            return Ok(StockDto);
        }

        [HttpGet("GetStockById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {   
            var stock = await _stockRepository.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost("CreateStock")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToStockFromCreateDto();

            var createdStock = await _stockRepository.CreateAsync(stock);

            return CreatedAtAction(nameof(GetById), new { id = createdStock.Id }, createdStock.ToStockDto());
        }

        [HttpPut("UpdateStockById/{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockDto stockDto)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            stock.Id = stockDto.Id;
            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.lastDiv = stockDto.lastDiv;
            stock.Purchase = stockDto.Purchase;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(stock.ToStockDto());
        }

        [HttpDelete("DeleteStockById/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return Ok(stock.ToStockDto());
        }
    }
}