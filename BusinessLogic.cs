using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lab4.Interfaces;

namespace Lab4
{   /// <summary>
    /// Business Logic almost identical to that of Lab2
    /// </summary>
    public class BusinessLogic : IBusinessLogic
    {
        private Database database;

        public BusinessLogic()
        {
            database = new Database();
            // Initialize BusinessLogic class with the database.
        }
        /// <summary>
        /// AddAirport
        /// Handles input from the UI performs data validation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <param name="dateVisited"></param>
        /// <param name="rating"></param>
        public void AddAirport(string id, string city, DateTime dateVisited, int rating)
        {
            if (!IsIdValid(id) || !IsCityValid(city) || !IsRatingValid(rating))
            {
                Console.WriteLine("Invalid airport details. Cannot add the airport.");
                //extra methods added to check if input is valid
                return;
            }

            if (AirportIdExists(id))
            {
                Console.WriteLine("Airport with the same ID already exists. Cannot add the airport.");
                return;
                //checks if an airport exists
            }

            Airport airport = new Airport(id, city, dateVisited, rating);


            database.InsertAirport(airport);
            //inserting it into databse (file)
            Console.WriteLine("Airport added successfully.");
        }

        public bool IsIdValid(string id)
        {
            return id.Length >= 3 && id.Length <= 4;
            //checking if the id is proper length
        }

        public bool IsCityValid(string city)
        {
            return city.Length < 25;
            //checking if the city is within the character limit
        }

        public bool IsRatingValid(int rating)
        {
            return rating >= 1 && rating <= 5;
            //checks if rating is between 1 & 5
        }

        public bool AirportIdExists(string id)
        {
            // Check if an airport with the same ID already exists in the database.
            Airport existingAirport = database.SelectAirport(id);
            return existingAirport != null;
        }
        /// <summary>
        /// DeleteAirport passes the airport
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAirport(string id)
        {
            Airport airportToDelete = FindAirport(id);
            database.DeleteAirport(airportToDelete);
            //asking database to delete airport with specified id
        }
        /// <summary>
        /// Edit Airport
        /// Checks input and calls the database layer
        /// to update an airport in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        /// <param name="dateVisited"></param>
        /// <param name="rating"></param>
        public void EditAirport(string id, string city, DateTime dateVisited, int rating)
        {
            Airport existingAirport = FindAirport(id);
            //finds an airport if it exists

            if (existingAirport == null)
            {
                Console.WriteLine("Airport not found. Cannot edit.");
                return;
            }

            if (!IsCityValid(city) || !IsRatingValid(rating))
            {
                Console.WriteLine("Invalid airport details. Cannot edit the airport.");
                return;
            }
            //checks all inputs are valid and updates the airport accordingly
            

            database.UpdateAirport(existingAirport, city, dateVisited, rating);
            Console.WriteLine("Airport edited successfully.");
        }
        /// <summary>
        /// FindAirport
        /// Checks to see if an airport is in the databse.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Airport</returns>
        public Airport FindAirport(String id)
        {
            return database.SelectAirport(id);
            //searching for airport in database based on ID
        }
        /// <summary>
        /// CalculateStatistics
        /// Returns a message about how many airports have been visited.
        /// Checks to see how many airports have been visited.
        /// Checks to see if there are 70 airports in the list to achieve bronze.
        /// </summary>
        /// <returns>String</returns>
        public string CalculateStatistics()
        {
            int totalAirports = database.SelectAllAirports().Count;
            //getting airport count from database
            string goal = "";
            int untilGoal = 0;
            string message;
            //checking how close to next goal we are
            if (totalAirports >= 125)
            {
                message = $"All goals achieved. {totalAirports} airports visited.";
            }
            else if (totalAirports < 42)
            {
                goal = "Bronze";
                untilGoal = 42 - totalAirports;
            }
            else if (totalAirports < 84)
            {
                goal = "Silver";
                untilGoal = 84 - totalAirports;
            }
            else if (totalAirports < 125)
            {
                goal = "Gold";
                untilGoal = 125 - totalAirports;
            }
            message = $"{totalAirports} airports visited; {untilGoal} airports remaining until achieving {goal}.";
            //format string to add all three fields and return to user interface
            return message;
        }
        /// <summary>
        /// Observable collection of airports used in the Business Logic layer.
        /// </summary>
        /// <returns>ObservableCollection<Airport></returns>
        public ObservableCollection<Airport> GetAirports()
        {
            return database.SelectAllAirports();
            //gets entire list of airports from database
        }
    }

}
