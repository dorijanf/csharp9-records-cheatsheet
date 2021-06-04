using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTutorial
{
    class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
