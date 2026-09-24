using System.Collections.Generic;

List<int> numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

int input;

Console.Write("Enter number: ");
input = int.Parse(Console.ReadLine());

while (input != 0)
{
    numbers.Add(input);
    Console.Write("Enter number: ");
    input = int.Parse(Console.ReadLine());
}

int sum = 0;
foreach (int number in numbers)
{
    sum = sum + number;
}

double average = (double)sum / numbers.Count;

int largest = numbers[0];
foreach (int number in numbers)
{
    if (number > largest)
    {
        largest = number;
    }
}

Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {largest}");

bool foundPositive = false;
int smallestPositive = 0;

foreach (int number in numbers)
{
    if (number > 0)
    {
        if (!foundPositive || number < smallestPositive)
        {
            smallestPositive = number;
            foundPositive = true;
        }
    }
}

if (foundPositive)
{
    Console.WriteLine($"The smallest positive number is: {smallestPositive}");
}

numbers.Sort();

Console.WriteLine("The sorted list is:");
foreach (int number in numbers)
{
    Console.WriteLine(number);
}