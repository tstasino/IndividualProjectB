using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Course
    {
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
         
        public override string ToString()
        {
            return $"Title: {Title} Stream: {Stream} Type: {Type} Start Date: {Start_Date} End Date: {End_Date}";
        }
    }
}
