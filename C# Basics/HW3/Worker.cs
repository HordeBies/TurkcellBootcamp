using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Worker : Human, IBootCampStudent
    {
        public string WorkplaceName { get; private set; }
        public Worker(string name, DateTime dateOfBirth, string workplaceName = "transitioning") : base(name, dateOfBirth)
        {
            WorkplaceName = workplaceName;
        }
        public void GoToWork()
        {
            Console.WriteLine($"{Name} işe gidiyor");
            StartWorking();
            //After 8 hours
            Rest();
        }
        public override void Rest()
        {
            base.Rest();
        }
        public string GetName() => Name;
        public void StartLearning()
        {
            //Might have to do something before starting to the bootcamp lesson
            StartWorking();
        }

        public void StopLearning()
        {
            Rest();
        }
    }
}
