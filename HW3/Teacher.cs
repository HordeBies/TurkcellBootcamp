using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Teacher : Human
    {
        public Teacher(string name, DateTime dateOfBirth) : base(name, dateOfBirth)
        {
        }
        public void Teach(List<IBootCampStudent> students)
        {
            Console.WriteLine($"Akşam oldu, {Name} önderliğinde bugünkü dersimiz başlıyor");
            StartWorking();
            foreach (var student in students)
            {
                //Öğrencilerin yoklamasını almak için isimlerine ihtiyacımız var
                student.GetName();
                student.StartLearning();
            }
            //After 5 hours
            foreach (var student in students)
            {
                student.StopLearning();
            }
            Console.WriteLine("5 saatlik dersimiz sona erdi");
            Rest();
        }
        public override void Rest()
        {
            base.Rest();
            if(Random.Shared.Next(6) == 6) // roll a dice and if its anything between 1 and 6 do nothing if its 7 do work (for ease of indexing everyting is substracted by 1 in calculations)
            {
                DoSomethingProductive();
            }
            else
            {
                DoNothing();
            }
        }
        private void DoSomethingProductive()
        {
            //Boring :((((
        }
        private void DoNothing()
        {
            //Very nice :))))
        }
    }
}
