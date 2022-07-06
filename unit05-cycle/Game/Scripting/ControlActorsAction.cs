using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);


        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            /// Snake 1
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.TurnHead(direction);

            /// Snake 2
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake2.TurnHead(direction2);

        }
    }
}