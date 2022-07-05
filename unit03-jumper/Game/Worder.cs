using System;
using System.Collections.Generic;


namespace unit03_jumper.Game
{
    /// <summary>
    /// Controls and keeps track of the word to be used for guessing
    /// </summary>
    public class Worder
    {
        public int location = 0;
        
        private string randWord = "";

        private int mistakes = 0;

        private char guess = 'a';
        private List<string> guesses = new List<string>();
        // List of all words that can be used in the program.
        private string[] allWords ={"tune", "team", "pop", "die", "dare", "boom", "fare", "lace", "swop", "log", "slot", "word", "help", "flex", "hand"}; 
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Worder. 
        /// </summary>
        public Worder()
        {
            Random random = new Random();
            randWord = allWords[random.Next(0, allWords.Length - 1)];
            foreach(char c in randWord) {
                guesses.Add("_");
            }
            
        }

        /// <summary>
        /// Prints the jumper depending on how many guesses or mistakes the user's had.
        /// </summary>
        /// <returns>A new hint.</returns>
        public void GetJumper()
    {   
            foreach(string c in guesses) {
                Console.Write(c);
            }
            Console.Write("\n");
            Console.Write("\n");
            // Print Jumper
            switch(mistakes) {
                case 0:
                    terminalService.WriteText(" ___   ");
                    terminalService.WriteText("/___\\  ");
                    terminalService.WriteText("\\   /  ");
                    terminalService.WriteText(" \\ /   ");
                    terminalService.WriteText("  0    ");
                    terminalService.WriteText(" /|\\   ");
                    terminalService.WriteText(" / \\   ");
                    break;
                case 1:
                    terminalService.WriteText("/___\\  ");
                    terminalService.WriteText("\\   /  ");
                    terminalService.WriteText(" \\ /   ");
                    terminalService.WriteText("  0    ");
                    terminalService.WriteText(" /|\\   ");
                    terminalService.WriteText(" / \\   ");

                    break;
                case 2:
                    terminalService.WriteText("\\   /  ");
                    terminalService.WriteText(" \\ /   ");
                    terminalService.WriteText("  0    ");
                    terminalService.WriteText(" /|\\   ");
                    terminalService.WriteText(" / \\   ");
                    break;
                case 3:
                    terminalService.WriteText(" \\ /   ");
                    terminalService.WriteText("  0    ");
                    terminalService.WriteText(" /|\\   ");
                    terminalService.WriteText(" / \\   ");

                    break;
                case 4:
                    terminalService.WriteText("  X    ");
                    terminalService.WriteText(" /|\\   ");
                    terminalService.WriteText(" / \\   ");

                    break;
                
            }
           
        }

        /// <summary>
        /// Whether or not the Word has been guessed.
        /// </summary>
        /// <returns>True if guessed or mistakes have been made; false if otherwise.</returns>
        public bool IsGuessed()
        {
            int right = 0;
            foreach(string c in guesses) {
                foreach(char r in randWord) {
                    if(c[0] == r) {
                        right++;
                    }
                }
            }

            if (randWord.Length == right) {
                return true;
            }
            else if(mistakes >= randWord.Length) {
                return true;
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Keeps track and updates the user's input and compares it to the word to be guessed..
        /// </summary>
        /// <param name="Guesser">The Guesser instance to watch.</param>
        public void WatchGuesser(Guesser guesser)
        {
            string userGuess = guesser.getGuess();
            List<string> pastGuesses = guesses;
            int index = 0;
            int errCount = 0;
            foreach (char c in randWord){
                if(c == userGuess[0]) {
                    guesses[index] = userGuess;
                    
                } else {
                    errCount++;
                }
                index++;
            }

            if(errCount == randWord.Length) {
                mistakes++;
            }
           
        }
    }
}