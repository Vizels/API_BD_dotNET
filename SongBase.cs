using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BD
{
    internal class SongBase : DbContext
    {
        public DbSet<Song> songs { get; set; }
        public SongBase() {
            Database.EnsureCreated();    
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=SongBase.db");
        }
        
    }
}
