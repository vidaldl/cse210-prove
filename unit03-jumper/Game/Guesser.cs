using System;


namespace unit03_jumper.Game
{
    /// <summary>
    /// Keeps track of user input and saves it and returns it.
    /// </summary>
    public class Guesser
    {
        private string guess = "";

        /// <summary>
        /// Constructs a new instance of Guesser.
        /// </summary>
        public Guesser()
        {
            guess = "";
        }

        /// <summary>
        /// Gets the current guess
        /// </summary>
        /// <returns>The current guess.</returns>
        public string getGuess()
        {
            return guess;
        }

        /// <summary>
        /// Sets the current guess from the user.
        /// </summary>
        /// <param name="guess">The current user's guess.</param>
        public void setGuess(string guess)
        {
            this.guess = guess;
        }

    }
}