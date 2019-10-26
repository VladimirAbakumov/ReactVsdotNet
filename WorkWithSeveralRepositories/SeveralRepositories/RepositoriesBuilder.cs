using System.Collections.Generic;

namespace SeveralRepositories
{
  public class RepositoriesBuilder
  {
    public static IReadOnlyList<IRepository> Build() =>
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
  }
}