using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Characters
{
    internal class Mage : Character
    {
        private int _mana;
        public int Mana
        {
            get
            {
                return _mana;
            }
            protected set
            {
                _mana = value;
                if (_mana < 0) _mana = 0;
            }
        }
        private int SpellManaCost = 5;
        private float SpellManaMultiplier = 1.5f;
        public Mage(string name, int health, int mana, int attackPower) : base(name, health, attackPower)
        {
            Mana = mana;
        }

        public override void Attack(ITargetable target) => CastSpell(target);
        private void CastSpell(ITargetable target)
        {
            int damage = AttackPower;
            Console.WriteLine("{0} casts a spell!", Name);
            if (Mana >= SpellManaCost)
            {
                Mana -= SpellManaCost;
                Console.WriteLine("{0} used {1} mana to enchance spell power by x{2}!", Name, SpellManaCost, SpellManaMultiplier);
                damage = (int)Math.Round(damage * SpellManaMultiplier, 0);
            }
            target.TakeDamage(damage);
        }
    }
}
