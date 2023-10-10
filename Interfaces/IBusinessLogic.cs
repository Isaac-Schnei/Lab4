using Lab4;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Interfaces;

public interface IBusinessLogic
{
    public void AddAirport(string id, string city, DateTime dateVisited, int rating);
    public void DeleteAirport(string id);
    public void EditAirport(string id, string city, DateTime dateVisited, int rating);
    public Airport FindAirport(String id);
    public string CalculateStatistics();
    public ObservableCollection<Airport> GetAirports();

}
