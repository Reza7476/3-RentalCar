namespace _3_RentalCar;

public class PickupTruck : Car
{
    public PickupTruck(int capacity, int id, string name, string manufacturedYear,
        decimal dailyRent, string manufactureCountry) :
        base(id, name, manufacturedYear, dailyRent, manufactureCountry)
    {
        Capacity = capacity;
    }
    public int Capacity { get; set; }

    public override void Details()
    {
        base.Details();
        Console.WriteLine($"\t Capacity: {Capacity}");
    }
}




