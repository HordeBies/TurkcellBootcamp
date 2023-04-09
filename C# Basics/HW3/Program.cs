using HW3;

var turkay = new Teacher("Türkay Ürkmez", new (1980, 1, 1));

var mehmet = new Worker("Mehmet Demirci", new (2000, 1, 1));
var irem = new Student("Irem Şahin", new(1999, 1, 1));
var buse = new Worker("Buse Deniz", new(1997, 1, 1));
var ali = new Student("Ali Türk", new(2000, 1, 1));

var bootcampers = new List<IBootCampStudent>() { mehmet, irem, buse, ali };


mehmet.GoToWork();
irem.GoToSchool();
buse.GoToWork();
ali.GoToSchool();

//haftasonu olsa
mehmet.Rest();
ali.Rest();

turkay.Teach(bootcampers);

//Tamamen farklı bir eğitim topluluğu da bu sistemi kullanarak oluşturulabilir mesela X öğrenci kotlin eğitim kursu kendi öğretmenleri önderliğinde