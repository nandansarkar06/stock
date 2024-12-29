using System;
using learning.Dtos;
using learning.Dtos.Stock;
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

    public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            lastDiv = stockDto.lastDiv,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }

}
