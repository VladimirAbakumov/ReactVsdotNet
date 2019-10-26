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
      var repositories = RepositoriesBuilder.Build();
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
      Console.WriteLine($"{DateTime.Now:O} Start");
      
      var repositories = RepositoriesBuilder.Build();

      var tasks = repositories.Select(r => r.GetEntities()).ToList();

      while (tasks.Any())
      {
        await Task.WhenAny(tasks);

        var entities = tasks.Where(t => t.IsCompleted).SelectMany(t => t.Result).ToList();
        entities.ForEach(Console.WriteLine);

        tasks = tasks.Where(t => !t.IsCompleted).ToList();
      }
    }

    private async IAsyncEnumerable<IReadOnlyList<Entity>> GetEntities(IReadOnlyList<IRepository> repositories)
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