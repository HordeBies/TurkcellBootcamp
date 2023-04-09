using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class SeminarRoomReservation : IReservable
    {
        public IReserver Reserver { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfAttendees { get; set; }
        public string SeminarTopic { get; set; }
        public SeminarRoomReservation(IReserver reserver, DateTime date, TimeSpan duration, int numberOfAttendees, string seminarTopic)
        {
            Reserver = reserver;
            Date = date;
            Duration = duration;
            NumberOfAttendees = numberOfAttendees;
            SeminarTopic = seminarTopic;
        }
        public bool Validate()
        {
            if (NumberOfAttendees < 20 || //At least 20 people for a seminar room reservation
                string.IsNullOrEmpty(SeminarTopic)|| //should have a real and not illegal reason for a seminar :)
                Date < DateTime.Now|| //As usual cant reserve for past
                Duration <= new TimeSpan(4,0,0)) //At least 4 hour for a seminar room reservation
            {
                return false;
            }
            return true;
        }
    }
}
