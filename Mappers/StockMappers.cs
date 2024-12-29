using System;
using learning.Dtos;
using learning.Models;

namespace learning.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stock)
    {
        return new StockDto
        {
            Id = stock.Id,
            Symbol = stock.Symbol,
            CompanyName = stock.CompanyName,
            Purchase = stock.Purchase,
            lastDiv = stock.lastDiv,
            Industry = stock.Industry,
            MarketCap = stock.MarketCap
        };
    }

}
