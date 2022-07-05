using System;
using System.Collections.Generic;


namespace unit02_hilo.Game
{
    /// <summary>
    /// The director controls the game
    /// </summary>
    public class Director
    {
        Card card = new Card();

        string guess = "";
        bool isPlaying = true;
        int score = 0;
        int totalScore = 300;

        /// <summary>
        /// Constructs a new instance of Director. Where a new instance of Card is created.
        /// </summary>
        public Director()
        {

            Card card = new Card();

        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Prints the first card generated in the constructor.
        /// Asks the user to guess if the next card will be higher or lower than the current one.
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine("The card is: " + card.value);
            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine();
        }

        /// <summary>
        /// 
        /// Updates the total score for the player.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }

            score = 0;
            
            card.Hilo(guess);
            score += card.points;
            
            totalScore += score;
        }

        /// <summary>
        /// Displays the current scores and asks the player if they wish to continue playing.
        /// Checks if the current player can continue playing.
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }

            string value = "";
            value = $"{card.value} ";
            

            Console.WriteLine($"Next card was: {value}");
            Console.WriteLine($"Your score is: {totalScore}\n");
            isPlaying = (totalScore > 0);
            if(isPlaying) {
                Console.Write("Play again? [y/n]");
                string playAgain = Console.ReadLine();
                isPlaying = (playAgain == "y");
            }
            
        }
    }
}


