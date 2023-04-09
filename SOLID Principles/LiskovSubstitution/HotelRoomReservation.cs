using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class HotelRoomReservation : IReservable
    {
        public IReserver Reserver { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfRooms { get; set; }
        public HotelRoomReservation(IReserver reserver, DateTime date, TimeSpan duration, int numberOfGuests, int numberOfRooms)
        {
            Reserver = reserver;
            Date = date;
            Duration = duration;
            NumberOfGuests = numberOfGuests;
            NumberOfRooms = numberOfRooms;
        }
        public bool Validate()
        {
            if(NumberOfRooms <= 0 ||
                NumberOfGuests <= 0 ||
                NumberOfGuests/NumberOfRooms > 5 ||
                Date < DateTime.Now || //Like a hotel with rooms with most occupancy of 4
                Duration < new TimeSpan(days:1,0,0,0)) //Minimum duration for a hotel room reservation is a day
            {
                return false;
            }
            return true;
        }

    }
}
