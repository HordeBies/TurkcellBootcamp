using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    internal class Company : IReserver
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string? Location { get; set; }
        public Company(string name, string email, string location) : this(name,email)
        {
            Location = location;
        }
        public Company(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
