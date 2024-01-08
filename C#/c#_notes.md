## C# Basics
### Arrays
- Most basic **collection type** in C#.
- Arrays are **fixed size**, size **cannot** be changed once created.

**Syntax**
```c#
// Declaring an array of size 3 that contains a maximum of 3 integer values
int[] numbers = new int[3];
// Assigning values to the arrays
numbers[0] = 1;
numbers[1] = 2;
numbers[2] = 3;
```
```c#
// Declare and initialize array
int[] numbers = new int[] { 1, 2, 3, 4, 5 }; // This creates an array of size 5
```
**Indexing Arrays**
```c#
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
int firstFromEnd = numbers[^1]; // print 5 on the console
int secondFromEnd = number[^2]; // print 4 on the console
```
**Two-Dimensional Arrays**
```c#
// Declare a two-dimensional array with 2 rows and 3 columns
char[,] letters = new char[2, 3];
// Setting values
letters[0, 0] = 'A';
letters[0, 1] = 'B';
letters[0, 2] = 'C';
letters[1, 0] = 'D';
letters[1, 1] = 'E';
letters[1, 2] = 'F';
```

```c#
// Declare and initialize array
char[,] letters = new char[,]
{
  { 'A', 'B', 'C' },
  { 'D', 'E', 'F' },
};
```

**Indexing Two-Dimensional Arrays**
```c#
letters[row, col];
```

### Lists
- The size of a list can be modified

**Syntax**
```c#
// Declaring a list
List<string> words = new List<string>();

// Declare and initialize a list
List<string> words = new List<string>
{
  "one",
  "two"
}
```

**Common properties and method of List type**
1) Add() - To add an element to the list
2) Remove(element) - To remove the given element from the list
3) RemoveAt(index) - Remove the element at the given index
4) AddRange(enumerable) - Add the given enumerable (ex. array) to the list
5) Count - Give the length of the list

### 'out' Keyword
- A parameter modifier, which lets you pass an argument to a method by reference rather than by value.
```c#
int numbers = new int[] {10, -8, 2, 12, -17};
List<int> onlyPositive = GetOnlyPositive(numbers, int out nonPositiveCount); // here the nonPositiveCount can be reference

List<int> GetOnlyPositive(
  int[] numbers,
  out int countOfNonPositive
)
{
  countOfNonPositive = 0;
  int result = new List<int>();
  foreach(int number in numbers) {
    if(number > 0) {
      result.Add(number);
    } else {
      countOfNonPositive++;
    }
  }
}
```

## Object-Oriented Programming (OOP) in C#
#### The need for OOP
- Separation of details, OOP can separate high-level business decisions from low-level technical details
- Code is **modular**, which makes it easier to **maintain**, **reuse**, and **modify**
- Code is **flexible**
- Code is easier to **understand**
- Easier to **control** how methods and data can be accessed, which makes the code **less error-prone**

### Basic Syntax
```C#
// Declaring a Rectangle instance
Rectangle rectangle = new Rectangle(3, 4);

public class Rectangle
{
  // fields - variables that belong to an object of a class
  // format for declaring a field: (access modifier) (variable type) (variable name);
  public int Width = 1; // we can initialize a value to fields, but it will be overwritten by the value passed into the constructor
  private int _height = 2; 

  Rectangle(int width, int height)
  {
    Width = width;
    _height = height;
  }

  public int CalcualateArea() {
    return Width * _height;
  }
}
```
- *The default parameterless constructor is only generated if we do not define one*

### Access Modifier
- Public - members can be accessed everywhere
- Private - members can only be accessed from within the class it belongs to
- Protected - 
- The default access modifier is **private**

### Abstraction
- Abstraction means that classes **expose only essential data and methods** and **hide** the underlying details
- Analogy: As a driver, we only need to know how to steer and step on the pedals, we do not need to understand how the engine works internally

### Encapsulation
- Bundling data with methods that operate on this data (in a single class)
- Use **data hiding** - to make data private instead of public





