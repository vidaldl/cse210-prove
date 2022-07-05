namespace unit03_jumper.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Worder worder = new Worder();
        private bool isPlaying = true;
        private Guesser guesser = new Guesser();
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            worder.GetJumper();
        }

        /// <summary>
        /// Starts the game by running the main game loop.
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
        /// Gets the input. And sets it on the guesser instance.
        /// </summary>
        private void GetInputs()
        {
            
            
            string guess = terminalService.ReadText("Guess a letter [a-z]: ");
            guesser.setGuess(guess);
            
            
        }

        /// <summary>
        /// Keeps tabs on the guesser's state.
        /// </summary>
        private void DoUpdates()
        {
            
            worder.WatchGuesser(guesser);
        }

        /// <summary>
        /// Checks if the game has ended, and prints the outputs.
        /// </summary>
        private void DoOutputs()
        {   
            
            
            if (worder.IsGuessed())
            {
                isPlaying = false;
                
            }

            worder.GetJumper();
        }
    }
}