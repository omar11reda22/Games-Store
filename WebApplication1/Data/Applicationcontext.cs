using Games.Models;
using Microsoft.EntityFrameworkCore;

namespace Games.Data
{
    public class Applicationcontext:DbContext
    {
        public Applicationcontext()
        {
            
        }
        public Applicationcontext(DbContextOptions options):base(options)
        {
            
        }
       public DbSet<Game> games { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<GameDevice> gameDevices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasData(new Category[] {
                    new Category{Id = 1 , Name = "action" },
                    new Category{Id = 2 , Name = "Sports" },
                    new Category{Id = 3 , Name = "Racing" },
                    new Category{Id = 4 , Name = "adventure" },
                    new Category{Id = 5 , Name = "fighting" },
                    new Category{Id = 6 , Name = "Films" },
                });

            modelBuilder.Entity<Device>()
                .HasData(new Device[] { 
                
                new Device{Id = 1 ,Name = "playstation" , Icon = "bi bi-playstation"},
                //new Device{Id = 2 ,Name = "playstation" , Icon = ""},
                //new Device{Id = 3 ,Name = "playstation" , Icon = ""},
                new Device{Id = 4 ,Name = "PC" , Icon = "bi bi-pc-display-horizontal"},
                new Device{Id = 5 ,Name = "Nintendo switch" , Icon = "bi bi-nintendo-switch"},
                new Device{Id = 6 ,Name = "XBOX" , Icon = "bi bi-xbox"}

                });




            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.gameid , e.deviceid});

            base.OnModelCreating(modelBuilder);
        }
    }
}
