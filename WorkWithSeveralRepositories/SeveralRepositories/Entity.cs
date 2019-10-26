using System;

namespace SeveralRepositories
{
  public class Entity
  {
    public Entity(int id, string data)
    {
      Id = id;
      Data = data;
    }

    public int Id { get; }
    
    public string Data { get; }

    public override string ToString() => $"{DateTime.Now:O} Entity {Id} with data: {Data}";
  }
}