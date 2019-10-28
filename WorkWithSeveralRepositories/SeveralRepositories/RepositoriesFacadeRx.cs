using System.Collections.Generic;
using System.Reactive.Subjects;

namespace SeveralRepositories
{
  public class RepositoriesFacadeRx
  {
    public Subject<IReadOnlyList<Entity>> Subject { get; }

    public RepositoriesFacadeRx() => Subject = new Subject<IReadOnlyList<Entity>>();

    public void Run()
    {
      var repositories = RepositoriesBuilder.Build();

      foreach (var repository in repositories)
        InvokeGettingValues(repository);
    }
    
    private void InvokeGettingValues(IRepository repository)
    {
      repository.GetEntities().ContinueWith(t => Subject.OnNext(t.Result));
    }
  }
}