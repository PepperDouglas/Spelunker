namespace Spelunker.Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameloop = new GameLoop(GameInit.GetPlayer(), GameInit.GetAllRooms(), 1);
            gameloop.Run();
        }
        
    }
}