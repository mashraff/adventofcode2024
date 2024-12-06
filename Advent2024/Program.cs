using Advent2024;

Console.WriteLine("Hello, World!");

//params
var dayNumber = 6;
var isTest = false;
var basePath = "C:\\Users\\muneeb2\\Source\\Repos\\adventofcode2024\\Advent2024\\";

var fileName = "Day" + dayNumber.ToString() + (isTest ? "_test" : "") + ".txt";
Console.WriteLine($"Reading file: {fileName}");
var input= await File.ReadAllTextAsync($"{basePath}/inputs/{fileName}");
Console.WriteLine(input);

var problemType = Type.GetType($"Advent2024.Days.Day{dayNumber}Problem");
if (problemType == null)
{
    throw new Exception("Problem not found.");
}

var problem = (IDayProblem)Activator.CreateInstance(problemType, input);

problem.SolvePart1();
problem.SolvePart2();


