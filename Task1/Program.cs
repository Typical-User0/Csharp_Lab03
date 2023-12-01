
struct Vector
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    public static Vector operator *(Vector v1, Vector v2)
    {
        return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
    }

    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.GetLength() > v2.GetLength();
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.GetLength() < v2.GetLength();
    }

    public double GetLength()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Vector vector1 = new Vector(0.0, 4.0, 3.0);
        Vector vector2 = new Vector(2.0, 5.0, 4.0);

        Vector sum = vector1 + vector2;
        Vector product = vector1 * vector2;
        Vector scaled = vector1 * 2.0;

        Console.WriteLine("Vector1 length: " + vector1.GetLength());
        Console.WriteLine("Vector2 length: " + vector2.GetLength());
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Product: {0}", product);
        Console.WriteLine("Scaled: {0}", scaled);
    }
}