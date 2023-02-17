using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dotnet_rpg.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> optinons) : base(optinons)
        {
            
        }
        public DbSet<Character> Characters => Set<Character>();

    }
}