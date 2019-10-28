using System;
using SeveralRepositories;

namespace RepositoriesClientAppRx
{
  static class Program
  {
    static void Main(string[] args)
    {
      var repository = new RepositoriesFacadeRx();
      repository.Subject.Subscribe(e =>
      {
        foreach (var entity in e)
          Console.WriteLine(entity);
      });
      repository.Run();

      Console.ReadKey();
    }
  }
}