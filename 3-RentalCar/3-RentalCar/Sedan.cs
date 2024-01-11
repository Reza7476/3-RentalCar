namespace _3_RentalCar;

public class Sedan : Car
{
    public Sedan(int id, string name, string manufacturedYear, decimal dailyRent,
        string manufactureCountry) :
        base(id, name, manufacturedYear, dailyRent, manufactureCountry)
    {
    }
    public override void Details()
    {
        base.Details();
    }
}




