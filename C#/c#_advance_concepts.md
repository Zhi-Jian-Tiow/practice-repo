## C# Advanced Concepts
### Funcs & Actions
- In C#, we can treat functions like any other types -> assign them to variables or pass them as parameters

**Func**
- Use the **Func** type to allow a method to take in a function as a parameter
```c#
Func<int, DateTime, string, decimal> someFunc; // this variable can be assigned any function that takes in an int, DateTime and string parameters, and returns a decimal 
```

**Action**
- Use **Action** type for **void functions**
```c#
Action<string, string, bool> someAction; // this variable can represent any void functions that takes in two string parameters and return a boolean
```

**Example**
```c#
int[] numbers = new[] { 1, 4, 7, 19, 2 };
Func<int, bool> predicate1 = IsLargerThan10;

Console.WriteLine(IsAny(numbers, predicate1));
Console.WriteLine(IsAny(numbers, IsEven));
bool IsLargerThan10(int number)
{
    return number > 10;
}

bool IsEven(int number) => number % 2 == 0;

// Allow the method to take in any function that is taking in a number and return a boolean
bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}
```

### Lambda Expression
- Use to define short simple **anonymous functions**
- Pattern = **(Param1, Param2) => expression**
```c#
int[] numbers = new[] { 1, 4, 7, 19, 2 };

// Passed in predicate using lambda expression
Console.WriteLine(IsAny(numbers, number => number % 2 == 0));

bool IsEven(int number) => number % 2 == 0;

// Allow the method to take in any function that is taking in a number and return a boolean
bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
{
    foreach (var number in numbers)
    {
        if (predicate(number))
        {
            return true;
        }
    }
    return false;
}
```

### Delegates
- A delegate is a type whose instances hold a reference to a method (or methods) with a particular parameter list and return type.
- **Funcs** & **Actions** are generic delegate

**Multicast delegate**
- A delegate variable that holds references to more than one function
- 
**Example**
```c#
using static System.Net.Mime.MediaTypeNames;

ProcessString processString1 = TrimTo5Letters;
ProcessString processString2 = ToUpper;

string TrimTo5Letters(string input)
{
    return input.Substring(0, 5);
}

string ToUpper(string input)
{
    return input.ToUpper();
}

delegate string ProcessString(string input);




// multicast delegates
Print print1 = text => Console.WriteLine(text.ToUpper());
Print print2 = text => Console.WriteLine(text.ToLower());
Print multicast = print1 + print2;
multicast("Crocodile"); // this will process both print1 and print2
delegate void Print(string input);
```

