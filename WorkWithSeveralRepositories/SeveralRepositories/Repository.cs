using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeveralRepositories
{
  public class Repository : IRepository
  {
    private readonly int _delay;
    private readonly int _id;

    public Repository(int id, int delay)
    {
      _id = id;
      _delay = delay;
    }

    public async Task<IReadOnlyList<Entity>> GetEntities()
    {
      await Task.Delay(_delay);

      const int entityCount = 3;
      var entities = new List<Entity>(entityCount);
      for (var i = 0; i < entityCount; i++) 
        entities.Add(CreateEntity(i));
      return entities;
    }

    private Entity CreateEntity(int localId) =>
      new Entity(_id * 100 + localId, $"entity created by Repository{_id} on {DateTime.Now:t}");

  }
}