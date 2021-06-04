using System;

namespace RecordTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new("Grommash", "Hellscream");
            Record1 r1b = new("Grommash", "Hellscream");
            Record1 r1c = new("Arthas", "Menethil");

            Class1 c1a = new("Grommash", "Hellscream");
            Class1 c1b = new("Grommash", "Hellscream");
            Class1 c1c = new("Arthas", "Menethil");

            Console.WriteLine("Record Type:");
            Console.WriteLine($"To String: {r1a}");
            Console.WriteLine($"Are the two objects equal: { Equals(r1a, r1b) }");
            Console.WriteLine($"Are the two objects reference equal: { ReferenceEquals(r1a, r1b) }");
            Console.WriteLine($"Are the two objects reference ==: { r1a == r1b }");
            Console.WriteLine($"Are the two objects reference !=: { r1a == r1c }");
            Console.WriteLine($"Hash code of object A: {r1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B: {r1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C: {r1c.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine("*************************");
            Console.WriteLine();

            Console.WriteLine("Class Type:");
            Console.WriteLine($"To String: {c1a}");
            Console.WriteLine($"Are the two objects equal: { Equals(c1a, c1b) }");
            Console.WriteLine($"Are the two objects reference equal: { ReferenceEquals(c1a, c1b) }");
            Console.WriteLine($"Are the two objects reference ==: { c1a == c1b }");
            Console.WriteLine($"Are the two objects reference !=: { c1a == c1c }");
            Console.WriteLine($"Hash code of object A: {c1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B: {c1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C: {c1c.GetHashCode()}");

            Console.WriteLine();

            var (fn, ln) = r1a;
            Console.WriteLine($"Firstname { fn }, Lastname { ln }");

            Record1 r1d = r1a with
            {
                FirstName = "Garrosh",
            };
            Console.WriteLine($"Garrosh's record: { r1d }");

            Record2 r2a = new("Sylvannas", "Windrunner");
            Console.WriteLine($"R2a value: { r2a }");
            Console.WriteLine($"R2a fn: { r2a.FirstName } ln: { r2a.LastName }");
            Console.WriteLine(r2a.SayHello());
        }
    }
}
