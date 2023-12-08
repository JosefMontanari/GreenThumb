using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        public AppDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumbDb;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Delete behaviour
            modelBuilder.Entity<PlantModel>()
                .HasMany(p => p.Instructions)
                .WithOne(p => p.Plant)
                .OnDelete(DeleteBehavior.Cascade);

            //Seedad data
            modelBuilder.Entity<PlantModel>().HasData(
            new PlantModel
            {
                PlantId = 1,
                Name = "Rose",
                Description = "Thorny, comes in a lot of colours. A universal symbol of love and admiration"

            },
            new PlantModel()
            {
                PlantId = 2,
                Name = "Elanor",
                Description = "Golden, star-shaped flower that grows in abundance in the forest of Lórien."
            },
            new PlantModel()
            {
                PlantId = 3,
                Name = "Cactus",
                Description = "Thorny useless plant, doesn't need a lot of water and requires little to no tending. Perfect gift " +
                "for children you don't like."
            });

            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel
                {
                    InstructionId = 1,
                    Instruction = "Six to eight hours of sun per day required.",
                    PlantId = 1,
                },
                new InstructionModel
                {
                    InstructionId = 2,
                    Instruction = "Plant in well drained soil rich with organic matter",
                    PlantId = 1,
                },
                new InstructionModel
                {
                    InstructionId = 3,
                    Instruction = "Keep away from orcs",
                    PlantId = 2,
                },
                new InstructionModel
                {
                    InstructionId = 4,
                    Instruction = "Water cautiously as to not drain the soil",
                    PlantId = 3,
                },
                new InstructionModel
                {
                    InstructionId = 5,
                    Instruction = "Keep away from children",
                    PlantId = 3,
                }
                );
        }
    }


}
