using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces;

public interface IDataBase
{
    /// <summary>
    /// Select Airport
    /// Returns null if airport is not found.
    /// </summary>
    /// <param name="Id"></param>
    /// <returns>Airport</returns>
    public Airport SelectAirport(String Id);
    /// <summary>
    /// Inserts an airport into the database.
    /// Returns true if the insertion was successful.
    /// </summary>
    /// <param name="airport"></param>
    /// <returns>Boolean</returns>
    public Boolean InsertAirport(Airport airport);
    /// <summary>
    /// Update Airport
    /// Updates an airport in the database.
    /// Returns true if the update was completed successfully.
    /// </summary>
    /// <param name="airportToUpdate"></param>
    /// <param name="city"></param>
    /// <param name="dateVisited"></param>
    /// <param name="rating"></param>
    /// <returns>Boolean</returns>
    public Boolean UpdateAirport(Airport airportToUpdate, String city, DateTime dateVisited, int rating);
    /// <summary>
    /// Delete Airport
    /// Returns true if the delete was completed successfully.
    /// </summary>
    /// <param name="airportToDelete"></param>
    /// <returns>Boolean</returns>
    public Boolean DeleteAirport(Airport airportToDelete);




}
