# C#9 Records
###### Dorijan Fabijanic
These are just notes I created following: [Intro to Records in C# 9](https://www.youtube.com/watch?v=9Byvwa9yF-I) by
[Tim Corey](https://iamtimcorey.com/).

## Overview
A record is a class with extra stuff. A record acts like a value type but it is a reference type just like any other class.

On a high level this class: 
```
class Class1
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}
```
:man_technologist: *Init means that you can only set the value in the constructor or when you create the class using
the curly brace syntax.*

is very similar to this record:
```
public record Record1(string FirstName, string LastName);
```
A record is immutable, which means that the valeus cannot be changed. It is something like a readonly class.
If we need the values to be changed we don't need a record, rather a class.

The "parameters" provided in the Record are a constructor signature, they are essentially properties
which is why  
:writing_hand: *we write Record parameters with PascalCase and not camelCase.*

## Differences between Records and Classes
Here I will underline the differences between Records and Classes.
### ToString
When we console.log a record it will display the values of the properties in curly braces and
the class will just display the namespace followed by the class name.
### Value and Reference types
When we take two objects we created for the same class with the same values, the compiler will recognize them
as different objects. Because it compares their location in the memory and not their values.
It is different for records. Two different records with the same values will be equal. They are two
different objects but they act as value types even though they are not. The compiler compares each property
in the entire object and if they are all equal then the objects itself are equal.
```
Record1 r1a = new("Grommash", "Hellscream");
Record1 r1b = new("Grommash", "Hellscream");
```
When comparing r1a and r1b objects r1a == r1b => true (also works for != and Equal()) 
ReferenceEqual() will be false.
## HashCode
r1a and r1b will both have the same hashcode. If two objects from the same class have the same values
they will have different hashcode because it is based on the memory location of those objects.
Two records on the other hand will have the same hashcode value because of the values which are the same.

:writing_hand: *This is very useful because if we want to check if a list has any duplicates in it we can
do a LINQ query and say give me all objects with unique hashcode values.*

## Deconstructor
```
var(fn, ln) = r1a;
Console.WriteLine($"{fn}, {ln}"); // Grommash, Hellscream
```
By assigning the record to an anonymous tuple it will deconstruct the properties of the record
into the values of the tuple

## Object copying
```
Record1 r1d = r1a with
{
    FirstName = "Garrosh",
};
Console.WriteLine($"Garrosh's record: { r1d }"); // Garrosh Hellscream
```

We can create copies of records and say take everything from this first object but everything after
the with keyword in curly braces will be changed to new values.

:man_technologist: *The **with** expression is introducted in C#9 and is used to create a copy of a 
record with specified properties*

## Difference between Struct and Record
**Records are Classes**, they just have extra stuff. A struct is a value type, it is not a class which means
it cannot be instantiated, inherited and so on.. Because records are classes we can inherit, instantiate them etc.

## Important Record features
- Records can have methods
- Record properties can be created in various ways
- We can use the class syntax for creating a record
- A record can inherit another record
- A record **CANNOT** inherit another class

### Explicit declaration of values
```
public record Record2(string FirstName, string LastName)
{
    internal string FirstName { get; init; } = FirstName;
    public string FullName { get => $"{ FirstName } { LastName }"; }
}
```
### Methods
```
public record Record2(string FirstName, string LastName)
{
    public string SayHello()
    {
        return $"Hello { FirstName }";
    }
}
```
### Full Properties
private string _firstName;

public string FirstName
{
    get { return _firstName.Substring(0, 1); }
    init { }
}

Records can also have full properties defined.  
:keyboard: *To create a full property faster we can type in the phrase propfull*

### Inheritance
A record can inherit only from another record, not from another class.
```
public record User1(int id, string FirstName, string LastName) : Record1(FirstName, LastName);
```

### Why use Records?
- Benefits  
  Records are extremely easy to setup and require less code to work. One line can replace tens of lines.
- Thread safe  
  If we have two threads working on the same object in the same time, if they both change the value of that object
  ,it can create a conflict and will blow up. Since we cannot change the value of a record then there are no
  problems. 

### When to use Records?
- If we are capturing external data that doesn't change.
- When we have our own API calls. If we are just getting the data we should use records, not classes  
- If we have 10,000 people in the database and return them we can probably populate records with that data
- We can classes that have Record types as properties as well which can oftentimes be useful.
- In general we use Records whenever we are just taking data and not modifying it (**Always when using READONLY data**)

### When not to use Records?
- When using Entity Framework or data that needs to change in any way

### NEVER DO THIS
```
public record Person // No constructor so no deconstructor (BAD!)
{
    public string FirstName { get; **set;** } // set makes this record mutable (BAD!)
}
```
Don't force records to be mutable when they are intended to be immutable.  
:man_technologist: *We should also never create clones just to update the state of objects.*

###### Legend
:man_technologist: - Coding tips I find to be important  
:writing_hand: - Coding conventions  
:keyboard: - Coding shortcuts and bindings  
