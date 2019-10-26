using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeveralRepositories
{
  public interface IRepository
  {
    Task<IReadOnlyList<Entity>> GetEntities();
  }
}