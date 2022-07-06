using System;


namespace unit05_cycle.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Growth : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Growth()
        {
            SetText("@");
            SetColor(Constants.RED); 
    
        }

      
    }
}