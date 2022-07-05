using System;


namespace unit02_hilo.Game
{

        /// <summary>
        /// Card keeps track of the values of the current card.
        /// 
        /// </summary> 
        public class Card {

            public int value = 0;
            public int points = 0;
            /// <summary>
            /// Constructs a new instance of Card, and generates a random number.
            /// </summary>
            public Card() {
                Random rand = new Random();
                value = rand.Next(1, 13);
            }
        
            /// <summary>
            /// Generates a new random value and calculates whether the guess made by the user is
            /// correct and assigns points accordingly.
            /// <param name="guess">User's guess</param>
            /// </summary>
           
            public void Hilo(String guess) {
                
                Random rand = new Random();
                int newVal = rand.Next(1, 13);

                if(guess == "h") {
                    if(value <= newVal) {
                        points =  100;
                    }
                    else {
                        points = -75;
                    }
                }
                else {
                    if(value >= newVal) {
                            points =  100;
                    }
                    else {
                        points =  - 75;
                    }
                }

                value = newVal;
                                
            }


        }

    
        
}