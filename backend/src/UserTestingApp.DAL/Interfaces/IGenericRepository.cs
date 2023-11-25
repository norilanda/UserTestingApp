using Ardalis.Specification;

namespace UserTestingApp.DAL.Interfaces;

public interface IGenericRepository<T> : IRepositoryBase<T> where T : class
{
}
