using System;

public class Employee
{
    private int salary;

    public string Name { get; set; }

    public int Salary
    {
        get
        {
            return salary;
        }
        set
        {
            // Salary cannot be negative.
            salary = value < 0 ? 0 : value;
        }
    }

    public Employee(string name, int salary)
    {
        Name = name;
        Salary = salary;
    }

    public static Employee operator +(Employee employee, int amount)
    {
        if (employee is null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount), "Amount cannot be negative.");
        }

        return new Employee(
            employee.Name,
            checked(employee.Salary + amount));
    }

    public static Employee operator -(Employee employee, int amount)
    {
        if (employee is null)
        {
            throw new ArgumentNullException(nameof(employee));
        }

        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount), "Amount cannot be negative.");
        }

        // The Salary property replaces negative values with zero.
        return new Employee(
            employee.Name,
            employee.Salary - amount);
    }

    public static Employee operator ++(Employee employee)
    {
        return employee + 500;
    }

    public static Employee operator --(Employee employee)
    {
        return employee - 500;
    }

    public static bool operator ==(Employee first, Employee second)
    {
        if (ReferenceEquals(first, second))
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Salary == second.Salary;
    }

    public static bool operator !=(Employee first, Employee second)
    {
        return !(first == second);
    }

    public static bool operator <(Employee first, Employee second)
    {
        if (first is null)
        {
            throw new ArgumentNullException(nameof(first));
        }

        if (second is null)
        {
            throw new ArgumentNullException(nameof(second));
        }

        return first.Salary < second.Salary;
    }

    public static bool operator >(Employee first, Employee second)
    {
        if (first is null)
        {
            throw new ArgumentNullException(nameof(first));
        }

        if (second is null)
        {
            throw new ArgumentNullException(nameof(second));
        }

        return first.Salary > second.Salary;
    }

    public override bool Equals(object obj)
    {
        if (obj is Employee other)
        {
            return Salary == other.Salary;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return Salary.GetHashCode();
    }
}