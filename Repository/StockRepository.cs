using System;
using learning.Data;
using learning.Interfaces;
using learning.Mappers;
using learning.Models;
using Microsoft.EntityFrameworkCore;

namespace learning.Repository;

public class StockRepository : IStockRepository
{   
    public readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Stock> CreateAsync(Stock stock)
    {
        await _context.Stocks.AddAsync(stock);

        await _context.SaveChangesAsync();

        return stock;
    }

    public async Task<Stock> DeleteAsync(int id)
    {
        var stock = _context.Stocks.Find(id);

        if (stock == null)
        {
            return null;
        }

        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();

        return stock;
        
    }

    public Task<List<Stock>> GetAllAsync()
    {
        return _context.Stocks.ToListAsync();
    }

    public async Task<Stock> GetByIdAsync(int id)
    {
        var stockModel = await _context.Stocks.FindAsync(id);

        if(stockModel == null)
        {
            return null;
        }

        return stockModel;
    }

    public Task<Stock> UpdateAsync(int id, Stock stock)
    {
        throw new NotImplementedException();
    }
}
