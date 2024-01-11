namespace _3_RentalCar;

public class Customer
{
    public Customer(int id, string name, string mobile)
    {
        Id = id;
        Name = name;
        Mobile = mobile;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public List<CarRental> rentalCars { set; get; }
}




