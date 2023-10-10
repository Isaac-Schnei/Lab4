using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab4
{
    /// <summary>
    /// Airport constructor has a property so it knows when something changed
    /// </summary>
    public class Airport : INotifyPropertyChanged
    {
        private string id;
        private string city;
        private DateTime dateVisited;
        private int rating;

        public event PropertyChangedEventHandler PropertyChanged;

        public Airport(string id, string city, DateTime dateVisited, int rating)
        {
            Id = id;
            City = city;
            DateVisited = dateVisited;
            Rating = rating;
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateVisited
        {
            get { return dateVisited; }
            set
            {
                if (dateVisited != value)
                {
                    dateVisited = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{Id} - {City}, {DateVisited.ToShortDateString()}, {Rating}";
        }


    }
}

