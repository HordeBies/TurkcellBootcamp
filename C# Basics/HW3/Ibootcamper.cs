using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal interface IBootCampStudent
    {
        public abstract string GetName();
        public abstract void StartLearning();
        public abstract void StopLearning();
    }
}
