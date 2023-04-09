using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.Enemies
{
    internal abstract class Enemy : ITargetable, IAttacker // , IAiControls to give ai control mechanism to MOBs
    {
        private int _health;
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                if (_health < 0) _health = 0;
            }
        }
        public bool IsAlive => Health > 0;

        public int AttackPower { get; private set; }

        public Enemy(int health, int attackPower)
        {
            Health = health;
            AttackPower = attackPower;
        }

        public abstract void Attack(ITargetable target);
        public virtual void Die()
        {
            Console.WriteLine("{0} has died!", GetType().Name);
        }

        public virtual void TakeDamage(int damage)
        {
            Console.WriteLine("{0} takes {1} damage!", GetType().Name, damage);
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }

    }
}
