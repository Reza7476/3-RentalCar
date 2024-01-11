namespace _3_RentalCar;

public class CarRental
{

    public CarRental(int id, string userName, string carName,
        int rentalDays, decimal dailyRentPrice)
    {
        Id = id;
        UserName = userName;
        CarName = carName;
        RentalDays = rentalDays;
        OrderDate = DateTime.Now;
        ReturnDate = DateTime.Now.AddDays(rentalDays);
        DailyRentPrice = dailyRentPrice;
        TotalPrice = SetTotalPrice(rentalDays , dailyRentPrice);
    }


    public int Id { get; set; }
    public string UserName { get; set; }
    public string CarName { get; set; }
    public int RentalDays { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal DailyRentPrice { get; set; }
    public decimal TotalPrice { get; private set; }
   

    public decimal SetTotalPrice(int rentaldays, decimal dailyRentPrice)
    {
        TotalPrice = rentaldays * dailyRentPrice;

        return TotalPrice;
    }


}




