using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OCP.Enemies
{
    internal class Dragon : Enemy
    {
        public Dragon(int health, int attackPower) : base(health, attackPower)
        {
        }

        public override void Attack(ITargetable target) => BreatheFire(target);

        private void BreatheFire(ITargetable target)
        {
            Console.WriteLine("{0} breathes fire!", GetType().Name);
            target.TakeDamage(AttackPower);
        }

        public override void Die()
        {
            Console.WriteLine("{0} turns to ash!", GetType().Name);
        }
    }
}
