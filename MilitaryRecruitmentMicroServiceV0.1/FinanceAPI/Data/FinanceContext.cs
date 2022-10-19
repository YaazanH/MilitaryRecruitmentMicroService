﻿using Microsoft.EntityFrameworkCore;

namespace FinanceAPI.Data
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
        { }

        public DbSet<FinanceAPI.Models.TransactionTicket> FinanceDb { get; set; }
    }
}

