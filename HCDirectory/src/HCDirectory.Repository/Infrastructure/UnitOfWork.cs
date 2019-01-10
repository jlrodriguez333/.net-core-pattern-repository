using HCDirectory.Repository.Repository;


namespace HCDirectory.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext Context)
        {
            dbContext = Context;

            // Repositories          
            Specialty = new SpecialtyRepository(dbContext);
        }
      
        public ISpecialtyRepository Specialty { get; private set; }
        public int Complete()
        {
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
