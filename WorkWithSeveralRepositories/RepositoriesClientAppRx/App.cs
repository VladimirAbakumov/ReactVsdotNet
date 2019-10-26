using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using SeveralRepositories;
using Console = System.Console;

namespace RepositoriesClientAppRx
{
  public class App
  {
    private readonly Subject<IReadOnlyList<Entity>> _subject;

    public App() => _subject = new Subject<IReadOnlyList<Entity>>();

    public void Run()
    {
      Console.WriteLine($"{DateTime.Now:O} Start");
      
      _subject.Subscribe(ShowEntities);
      
      var repositories = RepositoriesBuilder.Build();

      foreach (var repository in repositories)
        InvokeGettingValues(repository);

      Console.ReadLine();
    }

    private void InvokeGettingValues(IRepository repository)
    {
      Task.Run(
        async () =>
        {
          var entities = await repository.GetEntities();
          _subject.OnNext(entities);
        });
    }

    private void ShowEntities(IReadOnlyList<Entity> entities)
    {
      foreach (var entity in entities)
        Console.WriteLine(entity);        
    }
  }
}