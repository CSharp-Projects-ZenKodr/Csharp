﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Assignment_02
{
    [Serializable]
    class Driver : User
    {
        public DateTime LicenceValidationDate { get; set; }

        /*
         * Basic
         */
        private ICollection<Car> _cars = new List<Car>();
        private ICollection<Car> Cars
        {
            get => _cars.ToImmutableList();
            set => _cars = value ?? throw new NullReferenceException("Cars list cannot be null");
        }

        /*
         * With an attribute
         */
        private ICollection<Ride> _rides = new List<Ride>();
        public ICollection<Ride> Rides 
        {
            get => _rides;
            set => _rides = value ?? throw new NullReferenceException("Rides cannot be null!");
        }

        /*
         * Qualified
         */

        private IDictionary<string, City> _citiesQualif = new Dictionary<string, City>();

        public IDictionary<string, City> CitiesQualif
        {
            get => _citiesQualif;
            set => _citiesQualif = value ?? throw new NullReferenceException("Cities qualifier cannot be null!");
        }

        private List<Review> _reviews = new List<Review>();
        public List<Review> Reviews
        {
            get => _reviews;
            set => _reviews = value;
        }

        #region Constructors
        public Driver(string login, string password) : base(login, password)
        {
        }
        public Driver(string login, string password,
            string firstName, string lastName) : base(login, password, firstName, lastName)
        {
        }

        #endregion

        #region Qualified

        public void AddCityQualif(City newCity)
        {
            if (newCity is null) return;

            if (_citiesQualif.ContainsKey(newCity.CityName))
            {
                Console.WriteLine("Driver already belongs to this city");

                return;
            }

            _citiesQualif.Add(newCity.CityName, newCity);
        }

        public City FindCityQualif(string cityName)
        {
            if (!_citiesQualif.ContainsKey(cityName))
            {
                Console.WriteLine("There is no given city in the system.");

                return null;
            }

            return _citiesQualif[cityName];
        }

        #endregion

        #region Composition

        public void AddReview(Review review)
        {
            if (review is null || _reviews.Contains(review))
                return;

            _reviews.Add(review);
            
        }

        public void RemoveReview(Review review)
        {
            if (_reviews.Contains(review))
                _reviews.Remove(review);
            else
                Console.WriteLine($"The driver ${ToString()} does not contain review with id: {review.IdReview}");
        }

        #endregion

        #region With an attribute

        public void AddRide(Ride ride)
        {
            if (_rides.Contains(ride))
            {
                Console.WriteLine("The driver already has the given ride.");

                return;
            }

            _rides.Add(ride);
        }

        public void RemoveRide(Ride ride)
        {
            if (_rides.Contains(ride)) Rides.Remove(ride);

            Console.WriteLine("The driver does not have the given ride.");
        }

        #endregion

        #region Binary

        public void AddCar(Car car)
        {
            if (car == null || _cars.Contains(car)) return;

            _cars.Add(car);

            car.Driver = this;
        }

        public void RemoveCar(Car car)
        {
            if (car == null || !_cars.Contains(car)) return;

            _cars.Remove(car);
            car.Driver = null;
        }
        #endregion

        #region Class Method
        public static void ShowReviews(Driver driver)
        {
            if (driver._reviews.Count < 1)
            {
                Console.WriteLine($"Driver {driver.FirstName} does not have any reviews yet.");
                return;
            }

            foreach (Review review in driver._reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }

        #endregion

        public double GetAverageRate()
        {
            return _reviews.Average(s => s.Rate);
        }

        public override string ToString()
        {
            return Login;
        }
    }
}
