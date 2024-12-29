using System;
using learning.Models;

namespace learning.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();

}
