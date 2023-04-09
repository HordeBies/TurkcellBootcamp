using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OCP.Characters
{
    internal class Vampire : Character
    {
        public Vampire(string name, int health, int attackPower) : base(name, health, attackPower)
        {
        }

        public override void Attack(ITargetable target) => LifeSteal(target);

        private void LifeSteal(ITargetable target)
        {
            Console.WriteLine("{0} uses life steal attack!", Name);
            target.TakeDamage(AttackPower);
            var healAmount = AttackPower / 2;
            Health += healAmount;
            Console.WriteLine("{0} heals {1} health and has {2} health now.", Name, healAmount, Health);

        }
        public override void Die()
        {
            Console.WriteLine("{0} turns to dust!", Name);
        }
    }
}
