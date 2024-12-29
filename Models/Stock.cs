using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learning.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public  decimal Purchase { get; set; }
        public decimal lastDiv { get; set; }
        public decimal Industry { get; set; }
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}