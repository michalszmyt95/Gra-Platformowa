using System;
using System.Collections.Generic;

class Employee : IComparable<Employee>
{
    public int Salary { get; set; }
    public string Name { get; set; }

    public int CompareTo(Employee other)
    {
        // Alphabetic sort if salary is equal. [A to Z]
        if (this.Salary == other.Salary)
        {
            return this.Name.CompareTo(other.Name);
        }
        // Default to salary sort. [High to low]
        return other.Salary.CompareTo(this.Salary);
    }

    public override string ToString()
    {
        // String representation.
        return this.Salary.ToString() + ", " + this.Name;
    }
}

class Program
{
    static void Main()
    {
        List<Employee> list = new List<Employee>();
        list.Add(new Employee() { Name = "Steve", Salary = 10000 });
        list.Add(new Employee() { Name = "Janet", Salary = 10000 });
        list.Add(new Employee() { Name = "Andrew", Salary = 10000 });
        list.Add(new Employee() { Name = "Bill", Salary = 500000 });
        list.Add(new Employee() { Name = "Lucy", Salary = 8000 });

        // Uses IComparable.CompareTo()
        list.Sort();

        // Uses Employee.ToString
        foreach (var element in list)
        {
            Console.WriteLine(element);
        }

        Console.ReadKey();
    }
}