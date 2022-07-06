using System;
using System.Collections.Generic;
using System.Data;
using unit05_cycle.Game.Casting;
using unit05_cycle.Game.Services;


namespace unit05_cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        private int framesGrowth = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSnakeGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
                framesGrowth++;
            }
        }

        /// <summary>
        /// Updates the score and makes the snake grow.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSnakeGrowth(Cast cast)
        {
            /// Snake 1
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Score score = (Score)cast.GetFirstActor("score");
            Growth growth = (Growth)cast.GetFirstActor("growth");

            // Snake 2
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Score score2 = (Score)cast.GetFirstActor("score2");
            Growth growth2 = (Growth)cast.GetFirstActor("growth2");
            if (framesGrowth == 25)
            {
                int points = 1;
                snake.GrowTail(points);
                snake2.GrowTail(points);
                framesGrowth= 0;
            }

            
            
            
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            /// Snake 1
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            /// Snake 2
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();

            /// Snake 1
            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }
            
            /// Snake 2
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }


        /// <summary>
        /// Handles in case the game is over.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                // Snake 1
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                

                // Snake 2
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();
                

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                // Snake 1
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                

                // Snake 2
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
                
            }
        }

    }
}