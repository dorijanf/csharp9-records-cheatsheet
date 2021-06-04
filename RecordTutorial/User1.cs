using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordTutorial
{
    public record User1(int id, string FirstName, string LastName) : Record1(FirstName, LastName);
}
