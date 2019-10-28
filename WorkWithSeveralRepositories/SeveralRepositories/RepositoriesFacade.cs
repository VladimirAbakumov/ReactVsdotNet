using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeveralRepositories
{
  public class RepositoriesFacade
  {
    public async IAsyncEnumerable<IReadOnlyList<Entity>> GetEntities()
    {
      var repositories = RepositoriesBuilder.Build();
      
      var tasks = repositories.Select(r => r.GetEntities()).ToList();
      
      while (tasks.Any())
      {
        await Task.WhenAny(tasks);

        var entities = tasks.Where(t => t.IsCompleted).SelectMany(t => t.Result).ToList();
        yield return entities;
        
        tasks = tasks.Where(t => !t.IsCompleted).ToList();
      }
    }
  }
}