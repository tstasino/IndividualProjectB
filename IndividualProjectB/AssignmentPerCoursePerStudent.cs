using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class AssignmentPerCoursePerStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Assingment Description:{Description} Course Title: {Title} Stream: {Stream} Type: {Type}";
        }

    }
}
