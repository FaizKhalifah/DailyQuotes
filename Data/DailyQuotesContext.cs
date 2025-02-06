using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DailyQuotes.Models;

namespace DailyQuotes.Data
{
    public class DailyQuotesContext : DbContext
    {
        public DailyQuotesContext (DbContextOptions<DailyQuotesContext> options)
            : base(options)
        {
        }

        public DbSet<DailyQuotes.Models.Quote> Quote { get; set; } = default!;
    }
}
