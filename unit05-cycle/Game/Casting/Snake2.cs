using System;
using System.Collections.Generic;
using System.Linq;

namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake2 : Snake
    {

        
        public Snake2() {

        }
        
        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
         public override void PrepareBody() {
             int x = (Constants.MAX_X / 4) * 2;
                int y = Constants.MAX_Y / 4;

                for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
                {
                    Point position = new Point(x - i * Constants.CELL_SIZE, y);
                    Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                    string text = i == 0 ? "@" : "#";
                    Color color = Constants.GREEN;

                    Actor segment = new Actor();
                    segment.SetPosition(position);
                    segment.SetVelocity(velocity);
                    segment.SetText(text);
                    segment.SetColor(color);
                    segments.Add(segment);
                }
         }

         /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public override void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

            
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(Constants.GREEN);
                segments.Add(segment);
            }
        }
    }
}