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

    public Task<Stock> CreateAsync(Stock stock)
    {
        throw new NotImplementedException();
    }

    public Task<Stock> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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
