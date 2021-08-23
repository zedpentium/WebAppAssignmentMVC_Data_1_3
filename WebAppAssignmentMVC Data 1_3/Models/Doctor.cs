using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class Doctor
    {
        public int TempInput { get; set; }
        public string TempType { get; set; }


        public static string CheckFuncTheTemp(Doctor userFormInput)
        {
            string textMsg = "";
            int celciusFever = 37;
            int celciusHypoterm = 35;
            int fahrenheitFever = 99;
            int fahrenheitHypoterm = 95;

            int compareTempTypeFever = 0;
            int compareTempTypeHypo = 0;

            if (userFormInput.TempType == "C") {
                compareTempTypeFever = celciusFever;
                compareTempTypeHypo = celciusHypoterm;

            } else if (userFormInput.TempType == "F") {
                compareTempTypeFever = fahrenheitFever;
                compareTempTypeHypo = fahrenheitHypoterm;

            }


            if (userFormInput.TempInput > compareTempTypeFever)
            {
                textMsg = $"Your bodytemp of {userFormInput.TempInput}°{userFormInput.TempType} is high, you have a fever!";
            } else if (userFormInput.TempInput <= compareTempTypeHypo)
            {
                textMsg = $"Your bodytemp of {userFormInput.TempInput}°{userFormInput.TempType} is to low, your have hypotermia! Brrrrrr!";
            } else
            {
                textMsg = $"Your bodytemp of {userFormInput.TempInput}°{userFormInput.TempType} is Ok.";
            }


                return textMsg;
        }

    }
}
