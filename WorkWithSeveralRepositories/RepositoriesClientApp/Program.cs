using System.Threading.Tasks;

namespace RepositoriesClientApp
{
  internal static class Program
  {
    static async Task Main(string[] args)
    {
      await new App().RunConcurrently();
    }
  }
}