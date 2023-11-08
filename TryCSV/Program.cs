using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

// Define a class to represent your data structure
public class MyClass
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
}

public static class CsvHelperExample
{
    public static void WriteDataToCsv(string filePath, List<MyClass> data)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(data);
        }
    }

    public static List<MyClass> ReadDataFromCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<MyClass>().ToList();
        }
    }
}

// Usage example
class Program
{
    static void Main(string[] args)
    {
        var data = new List<MyClass>
        {
            new MyClass { Name = "John", Age = 30, Gender = "Male" },
            new MyClass { Name = "Doe", Age = 25, Gender = "Male" },
            new MyClass { Name = "Jane", Age = 28, Gender = "Female" }
        };

        // Writing data to a CSV file
        CsvHelperExample.WriteDataToCsv("data.csv", data);

        // Reading data from a CSV file
        var result = CsvHelperExample.ReadDataFromCsv("data.csv");

        // Printing the retrieved data
        foreach (var item in result)
        {
            Console.WriteLine($"Name: {item.Name}, Age: {item.Age}, Gender: {item.Gender}");
        }
    }
}