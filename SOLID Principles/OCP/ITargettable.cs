using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP
{
    internal interface ITargetable
    {
        public int Health { get; }
        public bool IsAlive { get; }
        void TakeDamage(int damage);
        void Die();
    }
}
