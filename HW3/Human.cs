using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal abstract class Human
    {
        protected Human(string name, DateTime dateOfBirth)
        {
            Name = name;
            this.dateOfBirth = dateOfBirth;
        }
        private readonly DateTime dateOfBirth;
        public string Name { get; private set; }
        public int Age => DateTime.Today.Year - dateOfBirth.Year; //simplest age calculation
        public bool IsWorking { get; private set; } = false;

        protected void StartWorking()
        {
            IsWorking = true;
        }
        public virtual void Rest()
        {
            IsWorking = false;
        }
    }
}
