using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class Person : IReserver
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Person(string name, string email, int age): this(name,email)
        {
            Age = age;
        }
        public Person(string name, string email)
        {
            Name = name;
            Email=email;
        }
    }
}
