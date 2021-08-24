using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebAppAssignmentMVC_Data_1_3;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class HomeViewModel
    {
        public string FilterInput { get; set; }
        public string btnFilter { get; set; }

        public string PersonName { get; set; }
        public string PersonPhoneNr { get; set; }
        public string PersonCity { get; set; }

        //public IEnumerable<People> Peoples { get; set; }



       /* public string CheckTheSearch(Peoplelist userFormInput, int theRndNr, out bool isItWin)
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
*/

        /*public class People
        {
            public string Name { get; set; }
            public string PhoneNr { get; set; }
            public string City { get; set; }
        }
        */


    }
}
