using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Student : Human, IBootCampStudent
    {
        public string SchoolName { get; private set; }
        public Student(string name, DateTime dateOfBirth, string schoolName="Mezun") : base(name, dateOfBirth)
        {
            SchoolName = schoolName;
        }
        public void GoToSchool()
        {
            Console.WriteLine($"{Name} için okula gitme vakti");
            StartWorking();
            //After 6 hours
            Rest();
        }
        public override void Rest()
        {
            base.Rest();
            PlayVideoGames();
        }
        private void PlayVideoGames()
        {
            //as a student what else would you do on your free time
        }
        public string GetName() => Name;

        public void StartLearning()
        {
            StartWorking();
        }

        public void StopLearning()
        {
            Rest();
        }
    }
}
