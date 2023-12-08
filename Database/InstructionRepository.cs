using GreenThumb.Models;

namespace GreenThumb.Database
{
    public class InstructionRepository
    {
        private readonly AppDbContext _context;
        public InstructionRepository(AppDbContext context, PlantModel plant)
        {
            _context = context;
        }

        public List<InstructionModel> GetAllInstructions(PlantModel plant)
        {
            return _context.Instructions.Where(p => p.PlantId == plant.PlantId).ToList();
        }

        public void AddInstruction(InstructionModel instruction)
        {
            _context.Instructions.Add(instruction);
        }

        public void RemoveInstruction(int id)
        {
            InstructionModel? instructionToRemove = _context.Instructions.FirstOrDefault(p => p.InstructionId == id);
            if (instructionToRemove != null)
            {
                _context.Instructions.Remove(instructionToRemove);
            }
        }
    }
}
