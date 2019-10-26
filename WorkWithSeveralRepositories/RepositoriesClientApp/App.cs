using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeveralRepositories;

namespace RepositoriesClientApp
{
  public class App
  {
    public async Task Run()
    {
      var repositories = CreateRepositories();
      var entityLists = GetEntities(repositories);

      Console.WriteLine("Start async foreach");
      await foreach (var entityList in entityLists)
      {
        foreach (var entity in entityList) 
          Console.WriteLine(entity);
      }
      
      Console.WriteLine("Ok");
    }

    public async Task RunConcurrently()
    {
      var repositories = CreateRepositories();

      var tasks = repositories.Select(r => r.GetEntities()).ToList();

      while (tasks.Any())
      {
        await Task.WhenAny(tasks);

        var entities = tasks.Where(t => t.IsCompleted).SelectMany(t => t.Result).ToList();
        entities.ForEach(Console.WriteLine);

        tasks = tasks.Where(t => !t.IsCompleted).ToList();
      }
    }

    private IReadOnlyList<Repository> CreateRepositories() =>
      new List<Repository>
      {
          new Repository(1, 3000),
          new Repository(2, 5000),
          new Repository(3, 3100),
          new Repository(4, 5000),
          new Repository(5, 10000),
          new Repository(6, 10000),
          new Repository(7, 100),
          new Repository(8, 100),
          new Repository(9, 100)
      };

    private async IAsyncEnumerable<IReadOnlyList<Entity>> GetEntities(IReadOnlyList<Repository> repositories)
    {
      Console.WriteLine("I am GetEntities");
      
      foreach (var repository in repositories)
      {
        Console.WriteLine("GetEntities from repository");
        var entities = await repository.GetEntities();
        Console.WriteLine("Entities have been received");
        yield return entities;
      }
    }
  }
}