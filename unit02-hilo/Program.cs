using unit02_hilo.Game;

namespace unit02_hilo
{
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static int Main(string[] args)
        {
            Director director = new Director();
            director.StartGame();
            return 0;
        }
    }
}
