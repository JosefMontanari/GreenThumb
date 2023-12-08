using GreenThumb.Models;

namespace GreenThumb.Database
{
    public class PlantRepository
    {
        private readonly AppDbContext _context;

        public PlantRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<PlantModel> GetAllPlants()
        {
            return _context.Plants.ToList();
        }

        public void AddPlant(PlantModel plant)
        {
            _context.Plants.Add(plant);
        }

        public void RemovePlant(int id)
        {
            PlantModel? plantToRemove = _context.Plants.FirstOrDefault(p => p.PlantId == id);
            if (plantToRemove != null)
            {
                _context.Plants.Remove(plantToRemove);
            }
        }


    }
}
