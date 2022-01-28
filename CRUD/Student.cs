using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Student
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public Student(string name, string gender, string @class, string section)
        {
            Name = name;
            Gender = gender;
            Class = @class;
            Section = section;
        }
    }
}
