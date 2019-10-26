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
  }
}