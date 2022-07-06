using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Directing;
using unit05_cycle.Game.Scripting;
using unit05_cycle.Game.Services;


namespace unit05_cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            // Snake 1
            Cast cast = new Cast();
            cast.AddActor("snake", new Snake());
            cast.AddActor("score", new Score(1));

            // Snake 2
            cast.AddActor("snake2", new Snake2());
            cast.AddActor("score2", new Score(2));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}