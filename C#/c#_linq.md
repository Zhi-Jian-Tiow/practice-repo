### Language Integrated Query (LINQ) ###
- LINQ is a set of technologies that allow simple and efficient querying over different kinds of data
- Allows **filtering**, **ordering** and **transforming** the collection elements, and more
- 2 ways to write LINQ queries: 1) Method Syntax, 2) Query Syntax
- LINQ can work with other types of collections like databases or XML files (syntax remains the same)

**Method Syntax**
```c#
var evenNumbers = numbers.Where(n => n % 2 ==0);
```

**Query Syntax**
```c#
var evenNumbers = from number in numbers where number % 2 == 0 select number;
```

**Benefits of LINQ**
- It allows a simple, efficient, and unified way of querying different types of data
- Queries execute only when the result is needed
- Code written with LINQ is cleaner, more readable and shorter


### Relationship between LINQ and IEnumerable Interface ###

## IEnumerable<T> Interface ##
- An interface implemented by most of the C# collections, eg. Array, List, HashSet & Dictionary
- This interface enables iterating a collection with a **foreach** loop
- Most LINQ methods are extension methods for IEnumerable<T>

## Deferred Execution ##
- **Deferred execution** means that the evaluation of a LINQ expression is delayed until the value is actually needed
- It improves performance by avoiding uneccessary execution, as the query is materialized only when it's actually needed

## Any method ##
- Any is used to check if any element in the collection matches the given criteria
```c#
int[] numbers = new int[] {5, 9, 2, 12, 6};
bool isAnylargerThan10 = numbers.Any(number => number > 10);
Console.WriteLine(isAnylargerThan10); // return true (because 12 is larger than 10)
```

## All method ##
- Check if all elements match the given criteria
```c#
int[] numbers = new int[] {5, 9, 2, 12, 6};
bool areAllLargerThanZero = numbers.All(number => number > 0);
Console.WriteLine(areAllLargerThanZero); // return true 
```

## Count & LongCount method ##
- Use to count the elements of the collection that match the given predicate
- The Count method returns **int**, the Longcount method returns **long**
```c#
```

## Contains method ##
- Check if a given element is present in the collection
```c#
int[] numbers = new int[] {5, 9, 2, 12, 6};
bool is7Present = numbers.Contains(7);
Console.WriteLine(is7Present); // return false 
```

## OrderBy method ##
- Orders the collection by some criteria

## OrderByDescending ##
- Orders the collection descendingly

**Notes**
- Both OrderBy and OrderByDescending methods can be chained together with the ThenBy method
- ThenBy method allows us to define the second criteria to sort the collection after the first criteria in OrderBy is met


## First & Last method ##
- The First method returns the first element from the collection. If a predicate is given, it returns the first element that matches this predicate
- The Last method works the same, instead it just returns the last element of the collection


## Where method ##
- Filters the collection based on the given predicate

## Distinct method ##
- Remove all the duplicated elements in the collection and return only a set of unique elements
```c#
int[] numbers = new int[] { 10, 1, 10, 4, 17, 17, 122 };
var numbersNoDuplicate = numbers.Distinct();
Console.WriteLine(numbersNoDuplicate); // return 10, 1, 4, 17, 122
```

## Select method ##
- Projects each element of a collection into a new collection
- Select method allows us to change the type of the collection using lambda functions (eg change an array of int to strings)
