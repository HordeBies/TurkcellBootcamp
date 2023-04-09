using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Neutral
{
    internal class Dummy : ITargetable
    {
        public string Name { get; } = "Dummy";
        public int Health { get; } = int.MaxValue;
        public bool IsAlive => true;
        public void Die()
        {
            //Dummy doesnt die
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine("{0} takes {1} damage!", Name, damage);
        }
    }
}
