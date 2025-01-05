using System;
using learning.Models;

namespace learning.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stock);
    Task<Stock> UpdateAsync(int id, Stock stock);
    Task<Stock> DeleteAsync(int id);

}
