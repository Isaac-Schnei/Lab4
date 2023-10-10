
using System.Collections.ObjectModel;
namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of your BusinessLogic class
            BusinessLogic businessLogic = new BusinessLogic();

            // Retrieve the list of airports using GetAirports
            ObservableCollection<Airport> airports = businessLogic.GetAirports();

            businessLogic.DeleteAirport("KATW");
            // Print the list of airports
            
        }


    }
}
