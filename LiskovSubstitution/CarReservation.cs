using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class CarReservation : IReservable
    {
        public IReserver Reserver { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string CarModel { get; set; }

        public CarReservation(IReserver reserver, DateTime date, TimeSpan duration, string carModel)
        {
            Date = date;
            Reserver = reserver;
            Duration = duration;
            CarModel = carModel;
        }
        public bool Validate()
        {
            //Check if reserver is not banned :D
            if (string.IsNullOrEmpty(CarModel) /*check from database if there is a car with that model is available*/ ||
                Duration < TimeSpan.Zero ||
                Date < DateTime.Now) // Cant make a reservation for past 
            {
                return false;
            }
            
            return true;
        }
    }
}
