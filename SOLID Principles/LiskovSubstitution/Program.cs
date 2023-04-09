using LiskovSubstitution;

ReservationManager reservationManager = new ReservationManager();

// Make a car reservation
DateTime carDate = new DateTime(2023, 4, 1);
TimeSpan carDuration = TimeSpan.FromDays(3);
IReserver carReserver = new Person("Ali Türk","aliturk@hotmail.com");
string carModel = "Tofaş Doğan SLX";
reservationManager.MakeReservation(carDate, carDuration, carReserver, carModel);

// Make a hotel room reservation
DateTime hotelDate = new DateTime(2023, 4, 5);
TimeSpan hotelDuration = TimeSpan.FromDays(4);
IReserver hotelReserver = new Company("Bies Corp.","corp@bies.co");
int numberOfGuests = 2;
int numberOfRooms = 1;
reservationManager.MakeReservation(hotelDate, hotelDuration, hotelReserver, numberOfGuests, numberOfRooms);

// Make a seminar room reservation
DateTime seminarDate = new DateTime(2023, 4, 11);
TimeSpan seminarDuration = TimeSpan.FromHours(5);
IReserver seminarReserver = new Person("Hasan Deniz","hasandeniz@gmail.com");
int numberOfAttendees = 20;
string seminarTopic = "Osmanlı Evlatlarının Senato Toplantısı";
reservationManager.MakeReservation(seminarDate, seminarDuration, seminarReserver, numberOfAttendees, seminarTopic);

//Or we can easily make reservation with IReservable implemented classes (for ease of use, i used same parameters you can populate with your examples)
var carReservation = new CarReservation(carReserver, carDate, carDuration, carModel);
reservationManager.MakeReservation(carReservation);

var hotelReservation = new HotelRoomReservation(hotelReserver,hotelDate,hotelDuration,numberOfGuests,numberOfRooms);
reservationManager.MakeReservation(hotelReservation);

var seminarReservation = new SeminarRoomReservation(seminarReserver,seminarDate,seminarDuration,numberOfAttendees,seminarTopic);
reservationManager.MakeReservation(seminarReservation);