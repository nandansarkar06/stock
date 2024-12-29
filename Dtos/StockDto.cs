using System;

namespace learning.Dtos;

public class StockDto
{
    public int Id { get; set; }
    public string Symbol { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public  decimal Purchase { get; set; }
    public decimal lastDiv { get; set; }
    public decimal Industry { get; set; }
    public long MarketCap { get; set; }
}
