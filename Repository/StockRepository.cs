using System;
using learning.Data;
using learning.Interfaces;
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
    public Task<List<Stock>> GetAllAsync()
    {
        return _context.Stocks.ToListAsync();
    }
}
