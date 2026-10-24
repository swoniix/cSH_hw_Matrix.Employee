using System;

class Program
{
    static void PrintMatrix(Matrix matrix)
    {
        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                Console.Write($"{matrix[row, col],6}");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main()
    {
        // Employee first = new Employee("John", 2000);
        // Employee second = new Employee("Anna", 3000);
        //
        // first = first + 1000;
        // Console.WriteLine($"After + 1000: {first.Salary}");
        //
        // first = first - 500;
        // Console.WriteLine($"After - 500: {first.Salary}");
        //
        // first++;
        // Console.WriteLine($"After ++: {first.Salary}");
        //
        // first--;
        // Console.WriteLine($"After --: {first.Salary}");
        //
        // Console.WriteLine($"Equal: {first == second}");
        // Console.WriteLine($"Not equal: {first != second}");
        // Console.WriteLine($"Less than: {first < second}");
        // Console.WriteLine($"Greater than: {first > second}");
        //
        // Employee third = new Employee("Mark", 2500);
        // Console.WriteLine($"Equals: {first.Equals(third)}");
        //
        // first = first - 10000;
        // Console.WriteLine($"After - 10000: {first.Salary}");
        //
        // first.Salary = 300;
        // first--;
        // Console.WriteLine($"After decrement from 300: {first.Salary}");
        //
        // first.Salary = -100;
        // Console.WriteLine($"After assigning -100: {first.Salary}");
        //
        // Employee fourth = new Employee("Alex", -500);
        // Console.WriteLine($"Negative starting salary: {fourth.Salary}");
        //
        // try
        // {
        //     first = first + (-100);
        // }
        // catch (ArgumentOutOfRangeException)
        // {
        //     Console.WriteLine("Negative amount rejected.");
        // }

        Matrix firstMatrix = new Matrix(new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Matrix secondMatrix = new Matrix(new int[,]
        {
            { 5, 6 },
            { 7, 8 }
        });

        Console.WriteLine("Addition:");
        PrintMatrix(firstMatrix + secondMatrix);

        Console.WriteLine("Subtraction:");
        PrintMatrix(firstMatrix - secondMatrix);

        Console.WriteLine("Matrix multiplication:");
        PrintMatrix(firstMatrix * secondMatrix);

        Console.WriteLine("Matrix * number:");
        PrintMatrix(firstMatrix * 3);

        Console.WriteLine("Number * matrix:");
        PrintMatrix(3 * firstMatrix);

        Matrix same = new Matrix(new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        });

        Console.WriteLine($"firstMatrix == same: {firstMatrix == same}");
        Console.WriteLine($"firstMatrix != secondMatrix: {firstMatrix != secondMatrix}");
        Console.WriteLine($"firstMatrix.Equals(same): {firstMatrix.Equals(same)}");

        same[0, 0] = 100;

        Console.WriteLine($"Changed element: {same[0, 0]}");
        Console.WriteLine($"Equal after change: {firstMatrix == same}");

        Matrix rectangular = new Matrix(new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        });

        Matrix column = new Matrix(new int[,]
        {
            { 1 },
            { 2 },
            { 3 }
        });

        Console.WriteLine("Rectangular multiplication:");
        PrintMatrix(rectangular * column);

        try
        {
            PrintMatrix(firstMatrix + rectangular);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }

        try
        {
            PrintMatrix(rectangular * firstMatrix);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}