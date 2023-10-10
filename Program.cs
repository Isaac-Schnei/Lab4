
using System.Collections.ObjectModel;
namespace Lab4
{
    class Program
    {
        /// <summary>
        /// this main method deletes everything to start testing again!
        /// no longer need to use since the tests delete the airports when done.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Create an instance of your BusinessLogic class
            BusinessLogic businessLogic = new BusinessLogic();

            // Retrieve the list of airports using GetAirports
            ObservableCollection<Airport> airports = businessLogic.GetAirports();

            businessLogic.DeleteAirport("KRHI");
            businessLogic.DeleteAirport("KETB");
            businessLogic.DeleteAirport("KATW");
            businessLogic.DeleteAirport("KEGR");
            businessLogic.DeleteAirport("KFLD");
            businessLogic.DeleteAirport("KLUM");

            // Print the list of airports

        }


    }
}
