using System;


namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>
    ///     Keeps the score
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        private int scoreType = 0;

        /// <summary>
        /// Constructs a new instance of an Score.
        /// </summary>
        public Score(int scoreType)
        {
            this.scoreType = scoreType;
            AddPoints(0);
            if(scoreType == 2) {
                Point newPosition = new Point(750, 0);
                SetPosition(newPosition);
            }
            
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            if(scoreType == 1) {
             SetText($"Player One: {this.points}");

            } else {
             SetText($"Player Two: {this.points}");

            }
        }

        
    }
}