using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class StudentPerCourse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"First Name: {FirstName} Last Name: {LastName} Title: {Title} Type: {Type}";
        }
    }
}
