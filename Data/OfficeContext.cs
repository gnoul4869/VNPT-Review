using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VNPT_Review.Models;

    public class OfficeContext : DbContext
    {
        public OfficeContext (DbContextOptions<OfficeContext> options)
            : base(options)
        {
        }

        public DbSet<VNPT_Review.Models.OFFICE> OFFICE { get; set; }
    }
