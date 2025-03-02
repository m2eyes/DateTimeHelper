// See https://aka.ms/new-console-template for more information
// read dates from text file and calculate the difference between them
using DateTimeHelper;
using System;
using System.IO;
using System.Globalization;

namespace DateTimeHelper.Test;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start Fetching Data from File!");
        Console.WriteLine("================================");
        string[] lines = File.ReadAllLines(@"..\..\..\TestCases.txt");
        int i = 0;
        foreach (var line in lines)
        {
            i++;
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            
            var dates = line.Split('-');
            if (dates.Length != 2)
            {
                Console.WriteLine("Invalid date format in line number: " + i);
                continue;
            }
            var startDate = DateTime.Parse(dates[0]);
            var endDate = DateTime.Parse(dates[1]);
            var dateDiff = startDate.DateDiff(endDate);
            Console.WriteLine($"Difference between {startDate} and {endDate} is {dateDiff.years} years, {dateDiff.months} months, {dateDiff.days} days, {dateDiff.hours} hours, {dateDiff.minutes} minutes, and {dateDiff.seconds} seconds");
            Console.WriteLine($"{startDate} Hijri Date is: {startDate.ToHijriDate()}");
            Console.WriteLine($"{endDate} Hijri Date is: {endDate.ToHijriDate()}");
            Console.WriteLine("================================");
        }
    }
}

