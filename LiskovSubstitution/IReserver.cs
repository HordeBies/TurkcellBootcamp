using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal interface IReserver
    {
        string Name { get; set; }
        string Email { get; set; }

    }
}
