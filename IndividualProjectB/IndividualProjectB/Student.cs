using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double TuitionFees { get; set; }

        public override string ToString()
        {
            return $"firstname: {FirstName} Lastname: {LastName} Date of Birth: {DateOfBirth} Tuition fees: {TuitionFees}";
        }
             
    }
}
