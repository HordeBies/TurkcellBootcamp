using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OCP.Enemies
{
    internal class Goblin : Enemy
    {
        public Goblin(int health, int attackPower) : base(health, attackPower)
        {
        }

        public override void Attack(ITargetable target) => Stab(target);
        private void Stab(ITargetable target)
        {
            Console.WriteLine("{0} attacks with a rusty sword!", GetType().Name);
            target.TakeDamage(AttackPower);
        }
    }
}
