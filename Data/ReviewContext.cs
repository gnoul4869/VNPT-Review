using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VNPT.Models;

    public class ReviewContext : DbContext
    {
        public ReviewContext (DbContextOptions<ReviewContext> options)
            : base(options)
        {
        }

        public DbSet<VNPT.Models.REVIEW> REVIEW { get; set; }
    }
