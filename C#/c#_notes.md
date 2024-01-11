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

  public Rectangle(int width, int height)
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
- Protected - members can be accessed from within the class or classes that inherited the class, but not outside
- The default access modifier is **private**

### Expression-Bodied Methods
- If a method only contains 1 expression or 1 statement, we can use expression-bodied method syntax
- Expression = code that evaluates to a value (ex. 1 + 2, or a method that returns a string)
- Statement = code that does not evaluates to a value (ex. Console.WriteLine("Hello");)

```c#
public class Rectangle
{
    private int _height;
    private int _width;

    // Expression-bodied method syntax
    public int CalculateArea() => _height * _width;
}
```

### Optional Parameters for Methods
- Optional parameters must be placed after all required parameters
- The default value must be compile-time constant, which means the value could be evaluated during code compilation
- In case of ambiguity, the constructor/methods with no optional parameters is used
```c#
public class MedicalAppointment
{
    private string _patientName;
    private DateTime _date;

    // When a new instance is created, this constructor will be prioritise because it has no optional parameters
    public MedicalAppointment(string patientName)
    {
        _patientName = patientName;
    }

    // Assign a default value for the parameter daysFromNow
    // This means if this argument is not provided, the default value is 7
    public MedicalAppointment(string patientName, int daysFromNow = 7)
    {
        _patientName = patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
    }
}
```
### readonly and const Keyword
- A **readonly** field can only be assigned at the declaration or in the constructor (if no value given, default value is used)
- The readonly field cannot be changed after the object is constructed (object is immutable)
- The **const modifier** can be applied to both **variables** and **fields**
- **const variables** and **fields** must be assigned a value at declaration with **compile time constant** and is immutable
- Use **readonly** fields when we want a field never to change **after it has been set in the constructor**
- Use **const** for things with a constant value known at **compilation time**
```c#
Rectangle rectangle = new Rectangle(10, 20);
rectangle.Height = 30; // This line would not compile, readonly field cannot be reassigned
public class Rectangle
{
    const int NumberOFSides = 4;
    public readonly int Width;
    public readonly int Height;

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
}
```

### Properties
**Fields vs properties**
- Fields are variable-like, and properties are method-like (a method to get and set private fields)
- We can have different access modifiers for getters and setters of properties, but only one access modifier for fields
- Properties **can be overridden** by the derived class, fields cannot be overridden.

```c#
public class Rectangle
{
    private int _width; //private _width field, also known as backing field of the Width property

    // public properties (name of properties must start with capital regardless of the access modifier)
    public int Width
    {
        get
        {
            return _width;
        }
        private set // we can use different access modifiers for getters and setters
        {
            _width = value;
        }
    }


    // we can shorten the syntax of a property if we only want to get and set a field
    // a backing field will be generated by the C# compiler, but we cannot access this backing field
    public int Height { get; private set; }
}
```

**Computed Properties**
- Properties can return a computed result
- Rule of thumb for computed properties -> should not be performance heavy
```c#
public class Rectangle
{
    private int _width;
    public int Width
    {
        get => _width;        
        private set => _width = value;        
    }

  // computed properties
  public string Description => $"A rectangle with width {_width}."; // this is a get only property
}
```

### Object Initializer
- We can use object initializer syntax to instantiate a new object
- If the setters of a property are not available or private, then we cannot use the object initializer to set the property value
- It is not a good idea to have the setter with public access modifier, so we can use the **init** keyword.
```c#
// The final value of the Name property is "John". This is because the constructor is called first, and then the object initializer is called
Person person = new Person("Adam")
{
    // setting properties are optional
    Name = "John",
    YearOfBirth = 1982
};

public class Person
{
    public string Name { get; set; }
    public int YearOfBirth { get; init; } // we can set the value via object initializer, but cannot reassign afterwards

    public Person(string name)
    {
      Name = name;
    }
}
```


### Abstraction
- Abstraction means that classes **expose only essential data and methods** and **hide** the underlying details
- Analogy: As a driver, we only need to know how to steer and step on the pedals, we do not need to understand how the engine works internally

### Encapsulation
- Bundling data with methods that operate on this data (in a single class)
- Use **data hiding** - to make data private instead of public

### Polymorphism
- Polymorphism is the provision of a **single interface** to entities of **different types**
- There is a generic concept of something (Ingredient), and this concept can be made concrete by multiple types (Cheddar, Mozzarella)

**Constructor / Method Overloading**
- We can define multiple constructors in a class, but the method signature must be different
- Method signature = method parameters + parameter type
```c#
public class MedicalAppointment
{
    private string _patientName;
    private DateTime _date;

    public MedicalAppointment(string patientName, DateTime date) 
        : this(patientName, 7) // use this keyword to call the constructor below
    {      
        // The constructor below will be called first because of the this keyword
        // Then only the code within this constructor will be executed
    }

    // method parameters type are different from the one above
    public MedicalAppointment(string patientName, int daysFromNow)
    {
        _patientName = patientName;
        _date = DateTime.Now.AddDays(daysFromNow);
    }
}
```

**Virtual Keyword
- **Virtual** methods or properties may be **overridden** by the inheriting types
- Virtual members cannot have private access modifier
```c#
public class Ingredient
{
    public virtual string Name { get; } = "Some ingredient";
}

// Cheddar class overrides the Name property of the inherited class
public class Cheddar : Ingredient
{
    public override string Name => "Cheddar cheese";
}
```

### Inheritance
- Inheritance enables us to create new classes that **reuse**, **extend**, and **modify** the behavior defined in other classes
- Inheritance is an **"is-a"** kind of relationship (ex, Cheddar is a type of ingredient)
- The base class consists of **common** methods or data to any of its derived types
- A derived type can contain members that the base class or other classes do not contain
- Fields that are public or protected within the base class are also inherited by the derived class (note that the value will be independent depending on instance class)
- C# does not support multiple inheritance

```c#
// base class
public class Ingredient
{
    public string PublicMethod() => "This method is PUBLIC in the Ingredient class";
}

// derived class - inherited from the Ingredient class
public class Cheddar : Ingredient
{
    public string Name => "Cheddar cheese";

    public void UseMethodsFromBaseClass() => Console.WriteLine(PublicMethod());
}
```

**base Keyword**
- The base keyword refers to the inherited class (base class)
- We use the base keyword to refer to the base class constructor or base class members
```c#
public class Ingredient
{   
    public int PriceIfExtraTopping { get; }
    public Ingredient(int priceIfExtraTopping)
    {
        PriceIfExtraTopping = priceIfExtraTopping;
        Console.WriteLine("Constructor from the Ingredient class");
    }

    public virtual string Name { get; } = "Some ingredient";
}

public class Cheddar : Ingredient
{
    public Cheddar(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
        Console.WriteLine("Constructor from the Cheddar class");
    }
    public override string Name => "Cheddar cheese";
}
```


### Static Methods & Classes
- We can make stateless (no data) class static (to use methods as a class, not from an instance of the class)
- **Static methods** belong to a class as a whole, not to a specific instance
- **Static methods** cannot use the instance data (values of fields or returned by properties or non-static methods)
- When all methods within a class are static, we can make the class static
- A **static class** cannot be instantiated, it only works as a container for methods
- **Static classes** can only contain **static methods**
- Good practice - if a **private** method **does not use instance data**, make it static
- All **const** fields are implicitly static

### Static Fields, Properties & Constructor
- Static fields and properties are used when a member is required to share between all instances
- We can directly assign a value to a static field/property, or we could use a static constructor to assign the value like a normal constructor
- Static constructor does not have access modifier, it only has a static keyword

### Implicit and Explicit Type Conversion
- **Implicit conversion** can only happen if conversion from one type to another is **safe** and **no data loss**
- **Explicit conversion** is risky and may lead to error (due to data loss) - this will cause an exception if casting fails
```c#
// implicit conversion (a decimal number can represent any integer)
int integer = 10;
double a = integer;

// explicit conversion (conversion will trim the data)
decimal c = 10.01m;
int d = (int) c;
```

** Upcasting & Downcasting**
- Upcasting = when converting a derived class to the base class (can be done with implicit conversion)
- Downcasting = when converting a base type to one of its derived classes (must use explicit conversion)

** is operator**
- Use to check if some object is of a given type

**as operator**
- We can perform explicit conversion with the **as operator**
- Using as operator will give **null** if casting fails
- as operator only works with **nullable** type
```c#
Ingredient ingredient = new Ingredient();
Cheddar cheddar = ingredient as Cheddar;
public class Ingredient
{

}

public class Cheddar : Ingredient
{

}
```

### Abstract Class
- **Abstract classes cannot be instantiated**. They only serve as **base classes** for other more concrete type
- Abstract classes can have abstract methods and abstract properties
- Can contain non-abstract methods 
```c#
public abstract class Ingredient
{
    public abstract void Prepare();
}

public class Cheddar : Ingredient
{
    public override void Prepare() => Console.WriteLine("Slice thinly and place on top of pizza.");
}
```

**Abstract Methods**
- Can only be defined in **abstract classes**
- Abstract methods **do not have implementation**
- All abstract methods are implicitly virtual (must be **overridden by non-abstract derived class**)

### Sealed Classes
- Prevent a class or method from being inherited/overridden
- Only **virtual methods** can be sealed
- **Static classes** are implicitly sealed
```c#
public class Cheddar : Ingredient
{
    public sealed override void Prepare() => Console.WriteLine("Slice thinly and place on top of pizza.");
}

public class SpecialCheddar : Cheddar
{
    // Would show compilation error because this method is sealed
    public override void Prepare()
    {

    }
}
```

### Interfaces
- Interfaces are used to define a base class for classes that are exposed to methods with the same signature
- Interfaces create a **"behave-like"** kind of relationship between types
- Interfaces cannot be instantiated
- All methods within an interface are implicitly virtual and have public access modifier 


### Interfaces vs Abstract Classes
**Interface**
- Defines the set of operations that the implementing type must provide
- Does not provide methods implementations
- Does not contain any data
- Interface is an abstraction of behaviour, which defines what an object can do
- Methods cannot be sealed or static
- Can only contain methods or properties definitions

**Abstract Classes**
- A blueprint for derived classes, representing a general category of things
- May provide implementations in non-abstract methods. Can also have abstract methods
- Can contain data
- Abstract class is an abstraction over alikeness, which defines what an object is
- Can contain sealed or static methods
- Can have implementations, fields and constructors
