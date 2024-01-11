namespace _3_RentalCar;
public class Car
{
    public Car(int id, string name, string manufacturedYear,
        decimal dailyRent, string manufacturedCountry)
    {
        Name = name;
        ManufacturedYear = manufacturedYear;
        DailyRentPrice = dailyRent;
        status = Status.NotRented;
        ManufacturedCountry = manufacturedCountry;
        Id = id;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string ManufacturedYear { get;private set; }
    public decimal DailyRentPrice { get; private set; }
    public string ManufacturedCountry { get; private set; }
    public Status status { get; private set; }
    
    public virtual void Details()
    {
        Console.WriteLine($" {Name} \n" +
            $"\t Manufactured Year: {ManufacturedYear} \n" +
            $"\t daily rent price: {DailyRentPrice} \n" +
            $"\t Made in: {ManufacturedCountry}\n" +
            $"\t statu: {status}");
    }
    public void ChangeStatusToReterned()
    {
        status = Status.Rented;
    }

    public void EditDailyRentPrice(decimal dailyRentPrice)
    {
        DailyRentPrice = dailyRentPrice;
    }
}

public enum Status
{
    Rented,
    NotRented
}




