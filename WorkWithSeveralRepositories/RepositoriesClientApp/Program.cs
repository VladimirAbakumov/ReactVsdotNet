using System;
using System.Threading.Tasks;
using SeveralRepositories;

namespace RepositoriesClientApp
{
  internal static class Program
  {
    static async Task Main(string[] args)
    {
      var repositories = new RepositoriesFacade();

      await foreach (var entities in repositories.GetEntities())
      {
        foreach (var entity in entities)
        {
          Console.WriteLine(entity);          
        }
      }
    }
  }
}