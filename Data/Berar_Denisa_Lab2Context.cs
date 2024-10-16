using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Berar_Denisa_Lab2.Models;

namespace Berar_Denisa_Lab2.Data
{
    public class Berar_Denisa_Lab2Context : DbContext
    {
        public Berar_Denisa_Lab2Context (DbContextOptions<Berar_Denisa_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Berar_Denisa_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Berar_Denisa_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
