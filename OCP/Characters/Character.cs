using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Characters
{
    internal abstract class Character : ITargetable, IAttacker // , IPlayerControls to give character control mechanism to user
    {
        private int _health;
        public string Name { get; protected set; }
        public int Health
        {
            get
            {
                return _health;
            }
            protected set
            {
                _health = value;
                if (_health < 0) _health = 0;
            }
        }
        public bool IsAlive => Health > 0;
        public int AttackPower { get; protected set; }
        public Character(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }
        public abstract void Attack(ITargetable target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.Write("{0} takes {1} damage", Name, damage);
            if (Health <= 0)
            {
                Console.WriteLine();
                Die();
            }
            else
            {
                Console.WriteLine(" and has {0} health left.", Health);
            }
        }

        public virtual void Die()
        {
            //Usually makes entity not targetable anymore and destroys the object after death animation
            Console.WriteLine("{0} has died!", Name);
        }
    }
}
