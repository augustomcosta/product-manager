using CrudProductManager.API.Domain.Models;
using CrudProductManager.API.Domain.Repositories.Base;

namespace CrudProductManager.API.Domain.Repositories;

public interface IProductRepository : IRepositoryBase<Product>
{ }