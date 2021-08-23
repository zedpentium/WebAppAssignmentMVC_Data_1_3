using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Game
    {
        public int GuessInput { get; set; }
        public string btnSubmit { get; set; }
        

        private static int nrOfGuesses = 0;
        private static int showNrOfGuessesAtWin = 0;


        public string CheckTheGuess(Game userFormInput, int theRndNr, out bool isItWin)
        {
            string textMsg = "";
            isItWin = false;

            if (userFormInput.GuessInput > theRndNr)
            {
                isItWin = false;
                nrOfGuesses++;
                textMsg = $"Your guessed {userFormInput.GuessInput} is to high, guess lower.\nYou guessed {nrOfGuesses} time(s).";

            }
            else if (userFormInput.GuessInput < theRndNr)
            {
                isItWin = false;
                nrOfGuesses++;
                textMsg = $"Your guessed {userFormInput.GuessInput} is to low, guess higher.\nYou guessed {nrOfGuesses} time(s).";

            /*} else if (userFormInput.GuessInput < 1 || userFormInput.GuessInput > 100)
            {
                isItWin = false;
                textMsg = $"Error! Your guessed {userFormInput.GuessInput} is to low, guess higher.\nYou guessed {nrOfGuesses} time(s).";
            */
            }
            else if (userFormInput.GuessInput == theRndNr)
            {
                isItWin = true;
                nrOfGuesses++;
                showNrOfGuessesAtWin = nrOfGuesses; // copying the nr of guesses, and put that in message,
                                                      // coz i set _nrOfGuesses = 0 before showing message
                textMsg = $"Congratulations! {userFormInput.GuessInput} is correct. You win!\nYou guessed {showNrOfGuessesAtWin} time(s).";
                nrOfGuesses = 0;
            }

                return textMsg;
        }
    
    }
}
