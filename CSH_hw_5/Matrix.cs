using System;

public class Matrix
{
    private int[,] _matrix;

    public int Rows
    {
        get{return _matrix.GetLength(0);}
    }

    public int Cols
    {
        get{return _matrix.GetLength(1);}
    }

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
        {
            throw new ArgumentOutOfRangeException("Dimensions Must be positive");
        }
        _matrix = new int[rows, cols];
    }

   
    public Matrix(int[,] values)
    {
        if (values is null)
        {
            throw new ArgumentNullException(nameof(values));
        }

        int rows = values.GetLength(0);
        int cols = values.GetLength(1);

        if (rows == 0 || cols == 0)
        {
            throw new ArgumentException("Matrix cannot be empty.");
        }

        _matrix = new int[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                _matrix[row, col] = values[row, col];
            }
        }
    } 
    //индексатор
    public int this[int row, int col]
    {
        get
        {
            return _matrix[row, col];
        }
        set
        {
            _matrix[row, col] = value;
        }
    }
    private static void ValidateMatrices(Matrix first, Matrix second)
    {
        if (first is null)
        {
            throw new ArgumentNullException(nameof(first));
        }

        if (second is null)
        {
            throw new ArgumentNullException(nameof(second));
        }
    }
    public static Matrix operator +(Matrix first, Matrix second)
    {
        ValidateMatrices(first, second);

        if (first.Rows != second.Rows || first.Cols != second.Cols)
        {
            throw new ArgumentException("Matrix dimensions must match.");
        }

        Matrix result = new Matrix(first.Rows, first.Cols);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Cols; col++)
            {
                result[row, col] = checked(
                    first[row, col] + second[row, col]);
            }
        }

        return result;
    }
    public static Matrix operator -(Matrix first, Matrix second)
    {
        ValidateMatrices(first, second);

        if (first.Rows != second.Rows || first.Cols != second.Cols)
        {
            throw new ArgumentException("Matrix dimensions must match.");
        }

        Matrix result = new Matrix(first.Rows, first.Cols);

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Cols; col++)
            {
                result[row, col] = checked(
                    first[row, col] - second[row, col]);
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix first, Matrix second)
    {
        ValidateMatrices(first, second);

        if (first.Cols != second.Rows)
        {
            throw new ArgumentException(
                "The first matrix's column count must equal the second matrix's row count.");
        }

        Matrix result = new Matrix(first.Rows, second.Cols);

        for (int row = 0; row < result.Rows; row++)
        {
            for (int col = 0; col < result.Cols; col++)
            {
                for (int k = 0; k < first.Cols; k++)
                {
                    result[row, col] = checked(
                        result[row, col] + first[row, k] * second[k, col]);
                }
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix matrix, int number)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        Matrix result = new Matrix(matrix.Rows, matrix.Cols);

        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                result[row, col] = checked(matrix[row, col] * number);
            }
        }

        return result;
    }

    public static Matrix operator *(int number, Matrix matrix)
    {
        return matrix * number;
    }

    public static bool operator ==(Matrix first, Matrix second)
    {
        if (ReferenceEquals(first, second))
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        if (first.Rows != second.Rows || first.Cols != second.Cols)
        {
            return false;
        }

        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Cols; col++)
            {
                if (first[row, col] != second[row, col])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool operator !=(Matrix first, Matrix second)
    {
        return !(first == second);
    }

    public override bool Equals(object obj)
    {
        if (obj is Matrix other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 31 + Rows;
            hash = hash * 31 + Cols;

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    hash = hash * 31 + _matrix[row, col];
                }
            }

            return hash;
        }
    }
}