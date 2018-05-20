using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DIGPES.Models
{
    public class DIGPESContext : DbContext
    {
        public DIGPESContext (DbContextOptions<DIGPESContext> options)
            : base(options)
        {
        }

        public DbSet<DIGPES.Models.PesquisaModel> PesquisaModel { get; set; }
    }
}
