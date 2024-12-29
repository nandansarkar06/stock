using System;
using learning.Models;
using Microsoft.EntityFrameworkCore;

namespace learning.Data;

public class ApplicationDBContext: DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {
        
    }

    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }

}
