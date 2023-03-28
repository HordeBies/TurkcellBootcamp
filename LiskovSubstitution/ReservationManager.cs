using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class ReservationManager
    {

        public void MakeReservation(IReservable reservation)
        {
            if (reservation.Validate())
            {
                Console.WriteLine("{0} on {1} for {2} was successfully made!", reservation.GetType().Name, reservation.Date, reservation.Duration);
            }
            else
            {
                Console.WriteLine("Invalid {0} on {1} for {2}!", reservation.GetType().Name, reservation.Date, reservation.Duration);
            }
        }

        public void MakeReservation(DateTime date, TimeSpan duration, IReserver reserver, string carModel)
        {
            CarReservation carReservation = new CarReservation(reserver, date, duration, carModel);

            MakeReservation(carReservation);
        }

        public void MakeReservation(DateTime date, TimeSpan duration, IReserver reserver, int numberOfGuests, int numberOfRooms)
        {
            HotelRoomReservation hotelReservation = new HotelRoomReservation(reserver,date,duration,numberOfGuests,numberOfRooms);

            MakeReservation(hotelReservation);
        }

        public void MakeReservation(DateTime date, TimeSpan duration, IReserver reserver, int numberOfAttendees, string seminarTopic)
        {
            SeminarRoomReservation seminarReservation = new SeminarRoomReservation(reserver,date,duration,numberOfAttendees,seminarTopic);

            MakeReservation(seminarReservation);
        }
    }
}
