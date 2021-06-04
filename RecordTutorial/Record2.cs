using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTutorial
{
    public record Record2(string FirstName, string LastName)
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }

        public string FullName { get => $"{ FirstName } { LastName }"; }

        public string SayHello()
        {
            return $"Hello { FullName }";
        }
    }
}
