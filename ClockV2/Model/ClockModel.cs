using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockV2.Model
{
    /// <summary>
    /// Class to represent the data and business logic layer for the Clock in the MVP design pattern.
    /// This class handles returning the Date and Time for the ClockView. It does not interact with the 
    /// ClockView directly but instead is called from the ClockPresenter that acts as the middleman to 
    /// pass data between the ClockModel and ClockView.
    /// </summary>
    public class ClockModel
    {


        /// <summary>
        /// Method to return the current date and time in DateTime format
        /// </summary>
        /// <returns>Returns the current Date and Time</returns>
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
