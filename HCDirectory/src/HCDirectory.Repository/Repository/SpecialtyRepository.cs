using HCDirectory.Repository.Infrastructure;
using HCDirectory.Repository.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HCDirectory.Repository.Repository
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<Specialty> GetByName(string name);       
    }

    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(ApplicationDbContext Context)
            : base(Context) { }        

        public async Task<Specialty> GetByName(string name)
        {
            var select = await Task.Run(() => (from spe in Context.Specialtys where spe.SpecialtyName == name select spe).FirstOrDefault());
            return select;
        }
    }

}
