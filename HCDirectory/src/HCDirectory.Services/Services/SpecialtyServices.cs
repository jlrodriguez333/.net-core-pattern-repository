using HCDirectory.Repository.Models;
using HCDirectory.Repository.Repository;
using System.Threading.Tasks;

namespace HCDirectory.Services.Services
{
    public interface ISpecialtyServices
    {
        Task<Specialty> GetByName(string name);
    }
    public class SpecialtyServices : ISpecialtyServices
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        public SpecialtyServices(ISpecialtyRepository specialtyRepository)
        {
            _specialtyRepository = specialtyRepository;
        }
        public async Task<Specialty> GetByName(string name)
        {
            return await _specialtyRepository.GetByName(name); 
        }
    }
}
