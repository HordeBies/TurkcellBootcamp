using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Neutral
{
    internal class Guard : IAttacker
    {
        public string Name { get; } = "Guard";
        public int AttackPower => int.MaxValue;

        public void Attack(ITargetable target)
        {
            Console.WriteLine("{0} attacks!", Name);
            target.TakeDamage(AttackPower);
        }
    }
}
