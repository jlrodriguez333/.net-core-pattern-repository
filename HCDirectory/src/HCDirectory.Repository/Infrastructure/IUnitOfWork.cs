using HCDirectory.Repository.Repository;
using System;

namespace HCDirectory.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {      
        ISpecialtyRepository Specialty { get; }
        int Complete();
    }
}
