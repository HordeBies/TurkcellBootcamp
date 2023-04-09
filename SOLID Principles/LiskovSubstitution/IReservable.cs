using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal interface IReservable
    {
        IReserver Reserver{ get; set; }
        DateTime Date { get; set; }
        TimeSpan Duration { get; set; }

        bool Validate();

    }
}
