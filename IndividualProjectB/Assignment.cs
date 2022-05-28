using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Assignment
    {
        //public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubDateTime { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        public override string ToString()
        {
            return $"Description: {Description} Submission date: {SubDateTime} Oral Mark: {OralMark} Total Mark: {TotalMark}";
        }
    }
}
