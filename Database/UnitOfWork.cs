namespace GreenThumb.Database
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        public PlantRepository PlantRepository { get; }
        public InstructionRepository InstructionRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            PlantRepository = new PlantRepository(context);
            InstructionRepository = new InstructionRepository(context);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
