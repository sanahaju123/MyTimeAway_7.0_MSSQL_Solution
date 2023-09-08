using Microsoft.EntityFrameworkCore;
using MyTimeAway.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTimeAway.DataLayer
{
    public class MyTimeAwayDbContext : DbContext
    {
        public MyTimeAwayDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeLeave> EmployeeLeaves { get; set; }
    }

}