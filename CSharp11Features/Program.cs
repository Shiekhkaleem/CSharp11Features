// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;
using static System.Convert;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Globalization;

Console.WriteLine("Hello, World!");



// 1 - Initiation of Object
Person person = new() { Id = 1, Name ="Kaleem Rehman", Birth = new(1993,09,09)};
Console.WriteLine( "My name is {0} having Id {1} and birthday is at {2}",person.Name , person.Id, person.Birth );
// 2 - Lists
List<Person> list = new()
{
 new(){Id =1,Name = "kaleem",Birth = new(1994,05,05) },
 new(){Id =2,Name = "Hamze",Birth = new(1994,05,05) },
 new(){Id =3,Name = "Umer",Birth = new(1994,05,05) },
};

// Set String Format
Console.WriteLine(
    format: "{0,-9} {1,5} {2,6}",
    arg0:"Id",
    arg1 : "Name",
    arg2:"Birth");
foreach (var item in list)
{
    Console.WriteLine(
        format:"{0,-9} {1,6:N0} {2,6:N0}",
        arg0:item.Id,
        arg1:item.Name,
        arg2:item.Birth.ToString());
}


// 3 - Default values

Console.WriteLine($"int default = {default(int)}");
Console.WriteLine($"bool default = {default(bool)}");
Console.WriteLine($"dateTime default = {default(DateTime)}");
Console.WriteLine($"string default = {default(string)}");

// 4 - Set Default Value

int number = default;
Console.WriteLine(  $"The default value of int is {number}");

string name = default;
Console.WriteLine($"The default value of string is {name}");

// 5 - return in if statements

List<int> numbers = new() { 1, 2, 3, 4, 5 };
for (int i = 0; i <= numbers.Count-1; i++)
{
    if (numbers[i] == 3)
    {
        Console.WriteLine( "The statement break" );  
        //Console.BackgroundColor = ConsoleColor.Red;
        Console.Error.WriteLine("There is an error in the code");
        Console.WriteLine("the success message");
        
       // return;    // this stope the code execution of code
    }
}


// 6 - if else statements without curly braces
// Note: If there is only single line code or statement inside each block then the proceeding code could be written without the curly braces.
string password = "ninja";
if(password.Length < 8)
    Console.WriteLine( "Your password is too short. Use at least 8 characters");
else
    Console.WriteLine("Your password is strong");


// 7 - pattern matching if statement
object o = 3;
int j = 4;
if (o is int p)
    Console.WriteLine($"{p} x {j} = {p * j}");
else 
    Console.WriteLine("o is not an int so it cannot multiply!");

// 8 - Switch case 
switch (o)
{
    case 1:
        Console.WriteLine( "The number is one" );
        break;
        case 2:
        Console.WriteLine("The number is two");
        break;
        case 3:
        case 4:
        Console.WriteLine("The number is three and four");
        break;
        case 5:
        goto case 1;      // this case  true then it go to case 1 and break
    default:
        break;
}

//  9 - IEnumerable List     All the collections and lists are enumerable in this approach the data gets in 

var result = from num in numbers
             where num > 3
             select num;
foreach (var item in result)
{
    Console.WriteLine(item);
}

// 10 - IQueryable list  is used to get data from database and its is in different way and the query that is created build and run on database.  

IEnumerable<int>  enumerableList = from nums in numbers
                                   where nums == 4
                                   select nums;
foreach (var item in enumerableList)
{
    Console.WriteLine(item);
}
Console.WriteLine("");

int numberOne = numbers.FirstOrDefault(x => x == 3);
Console.WriteLine(  $"the number is {numberOne}");


// 11 - Two dimensional array

string[,] fruitsTable = new[,]
{
        { "apple","mango","banana"},
        { "watermelon","strawberry","blackberry"},
        { "guava","grapes","pear"}
};

for (int row = 0; row <= fruitsTable.GetUpperBound(0); row++)
{
    for (int col = 0; col <= fruitsTable.GetUpperBound(1); col++)
    {
        Console.WriteLine(
            format:"{0, 6} {1,9:N0} {2,8:N0}",  arg0: $"{fruitsTable[row,col]}", arg1: $"{fruitsTable[row,col + 1]}", arg2: $"{fruitsTable[row,col + 2]}");
        break;
    }
}
// 12 - Multidimensional Array
string[][] jaggedArray = new[]
{
  new[] { "apple", "mango", "banana" },
  new[] { "watermelon","strawberry","blackberry" },
  new[]      { "guava","grapes","pear"}
};

// 13 - Switch statement in lambda experssions

static string FindNumber(int num) => num switch
{
    1 => "The number is one",
    2 => "The number is two",
    3 => "The number is three"
};
Console.WriteLine(FindNumber(2));
int z = 3;
string answer = z switch
{
    1 => "The number is one",
    2 => "The number is two",
    3 => "The number is three"
};

// 14 - Casting of variables
// Add - using static System.Convert; as static in namespace reference to access methods
int num1 = 10;
string value = Convert.ToString(num1)?? default; 
string numValue = "10";
int a = ToInt32(numValue);

// Converting from bytes to string
byte[] bytes = new byte[128];
string base64 = ToBase64String(bytes);

// parsing from string to int and date time
// The opposite of ToString is Parse. Only a few types have a Parse method , including all the number types and datetime.

int age = int.Parse("28");
DateTime dob = DateTime.Parse("2000-07-07");


// TryParse Method 

string input = "12";
if (int.TryParse(input, out int total))
{

//}
}

// 15 - Try Catch

//try
//{
//    throw new NullReferenceException();
//catch (Exception ex)
//{

//    Console.WriteLine( "Error Type :"+ ex.GetType() + " \n Error Message:" + ex.Message );
//}


// 16 - If statment return
if (string.IsNullOrEmpty(input)) return;

// 17 - Find Factorial 
Console.WriteLine(Factorial(5));
static int Factorial(int number)
{
    if (number < 0)
    {
        throw new ArgumentException(message:"The factorial of negative integers is not possible",paramName:nameof(number));
    }
    else if (number == 1)
    {
        return 1;
    }
    else 
    {
        return number * Factorial(number - 1);
    }
}


// 18 - Debug and Trace. When you are working with API that has no interface then you can console, debug and trace your code. This can be view on output window.

Debug.WriteLine("This is debugging tool.");
Trace.WriteLine("This is tracing tool.");

// 19 - Writing on text file in system.

//string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
//string filePath = Path.Combine(Environment.CurrentDirectory,"logs.txt");
//if (!Directory.Exists(logPath))
//    Directory.CreateDirectory(logPath);

//TextWriterTraceListener traceListener = new(File.CreateText(logPath));

//Trace.Listeners.Add(traceListener);

//Trace.AutoFlush = true;
// 20 - Environment Functions

var machineName = Environment.MachineName.ToUpperInvariant();
Console.WriteLine(machineName);
var hardDrives = Environment.GetLogicalDrives();
Console.WriteLine(hardDrives[0] + " " + hardDrives[1]);


// 21 - Adding appsettings file in console app.

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


// 22 - Understanding Types of Testing


// 23 - Building Types With OOP
//Struct , class, record are user data types
// structs are value types , classes are reference types and records are by default immutable reference types. 
//Note: Structs are stored on the stack and classes are stored on the heap.
// In the class Employee you can see that we set constructor of that and set properties in it due that.

// Before start we have to clear the difference between stack and heap
// heap and stack both have physical location in system RAM. When we declare any value like
int stackNumber = 10; // this store in stack 
int heapNumber = new();     // this is store in heap 
// An instance of class is named an object while an instance of a struct is named a value
//Objects typically have a more extended liftime and persist in memory untill they are no longer reachable, at which point they become eligible for garbage collection.
//An object is no longer reachable when no more references point to that object.
//Garbage collection is a process that auomatically recalims memory accoupied by objects that are no longer in use, ensuring efficient memory utilization
Employee employee = new(id: 10, name: "kaleem", birth: DateTime.Parse("2023-09-09"));
Person personObj = new() { Id = 12, Name = "kaleem", Birth = DateTime.Parse("2023-09-09") };
//In the above example we can see the difference between them that we  in the employee class i have set the constructor and after that when I initialize the class and set values in the Constructor;
// but I cannot set in person object.

// strcut
Point point = new Point(2, 2);
// here the copy of this object created here instead of reference like in 

// record 
// the record are introduced in c# 9 and are new data types like classes

Date date = new Date(2023, 2, 14);
Console.WriteLine(date.GetMonthName());

// 23 - string comparison
string str1 = "apple";
string str2 = "Apple";
var comp = String.Equals(str2, str1, StringComparison.Ordinal);
Console.WriteLine(comp);
//Classes

class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Birth { get; set; }
}

class Employee
{
    public Employee(int id , string? name , DateTime birth)
    {
           Id = id;
           Name = name;
           Birth = birth;
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Birth { get; set; }
}

public record Date(int Year, int Month, int Day)
{
    public string GetMonthName()
    {
        return DateTimeFormatInfo.CurrentInfo.GetMonthName(Month);
    }
}

struct Point
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}