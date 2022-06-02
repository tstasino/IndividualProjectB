using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class AssignmentPerCourse
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"Assignment Description: {Description} Course Title: {Title} Type: {Type}";
        }
    }
}
