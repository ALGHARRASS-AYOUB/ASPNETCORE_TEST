using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EXERCICE1.Models;

namespace EXERCICE1.Data
{
    public class EXERCICE1Context : DbContext
    {
        public EXERCICE1Context (DbContextOptions<EXERCICE1Context> options)
            : base(options)
        {
        }

        public DbSet<EXERCICE1.Models.User> User { get; set; } = default!;
    }
}
