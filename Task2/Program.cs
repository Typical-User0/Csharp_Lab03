
class Car : IEquatable<Car>
{
    public string Name { get; }
    public string Engine { get; }
    public int MaxSpeed { get; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car? other)
    {
        if (other == null)
            return false;

        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
}

class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public string this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
            {
                return $"{cars[index].Name}, Engine: {cars[index].Engine}";
            }
            else
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    public int Count()
    {
        return this.cars.Count;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car("Toyota", "V6", 200);
        Car car2 = new Car("Honda", "V4", 180);

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);

        Console.WriteLine("Cars in the catalog:");
        for (int i = 0; i < catalog.Count(); i++)
        {
            Console.WriteLine($"Car {i + 1}: {catalog[i]}");
        }
    }
}