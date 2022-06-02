using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Trainer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public override string ToString()
        {
            return $"firstname: {FirstName} Lastname: {LastName} Subject: {Subject}";
        }
    }
}
