

using _3_RentalCar;

while (true)
{
    try
    {
        int execute = RentalCarOffice.Run();
        switch (execute)
        {
            case 0:
                {

                    Environment.Exit(0);
                    break;
                }
            case 1:
                {
                    var name = RentalCarOffice.GetString("Enter car's name");
                    var manufactureYear = RentalCarOffice.GetDate("Enter manufacture year");
                    var dailyRent = RentalCarOffice.GetInteger("enter daily rent price ");
                    var manufactureContry = RentalCarOffice.GetString("enter manufactured country");
                    var mentionTypeOfCar = RentalCarOffice.GetInteger($" \t{name} is a " +
                        $"\n\t1: sadan car \n\t2: pickup car  ");
                    if (mentionTypeOfCar == 2)
                    {
                        var Capacity = RentalCarOffice.GetInteger("enter capacity ");
                        RentalCarOffice.AddNewCar(name, manufactureYear.ToString(), dailyRent, manufactureContry, Capacity);
                    }
                    else
                    {
                        RentalCarOffice.AddNewCar(name, manufactureYear.ToString(),
                            dailyRent, manufactureContry);
                    }
                    break;
                }
            case 2:
                {

                    var name = RentalCarOffice.GetString("enter customer name");


                    var mobile = RentalCarOffice.GetString("enter customer mobile");
                    RentalCarOffice.AddNewCostumer(name, mobile);
                    break;
                }
            case 3:
                {
                    var customerName = RentalCarOffice.GetString("enter customer name");
                    Console.WriteLine($"*******\nPickUpTruck Cars\n");
                    RentalCarOffice.ShowTruck();
                    Console.WriteLine($"*******\nSedan Cars\n");
                    RentalCarOffice.ShowSedan();
                    var carName = RentalCarOffice.GetString("Enter the requested car name according to the list.");
                    var rentalDays = RentalCarOffice.GetInteger("enter days you need car");
                    RentalCarOffice.RentCar(customerName, carName, rentalDays);
                    break;
                }
            case 4:
                {
                    var carName = RentalCarOffice.GetString("enter car name");
                    RentalCarOffice.DisplayCarDetails(carName);
                    break;
                }


            case 5:
                {
                    Console.WriteLine($"*******\nPickUpTruck Cars\n");
                    RentalCarOffice.ShowTruck();
                    Console.WriteLine($"*******\nSedan Cars\n");
                    RentalCarOffice.ShowSedan();
                    break;
                }

            case 6:
                {
                    var carName = RentalCarOffice.GetString("enter car's name");
                    var car = RentalCarOffice.GetCarByName(carName);
                    if (car != null)
                    {
                        Console.WriteLine($"  old rent price: {car.DailyRentPrice}");
                        var newDailyRentPrice = RentalCarOffice.GetInteger("enter new rent price");
                        RentalCarOffice.EditDailyRentPrice(carName, (decimal)newDailyRentPrice);
                    }
                    else
                    {
                        throw new Exception("car not found");
                    }
                    break;
                }

            case 7:
                {

                    var customerName = RentalCarOffice.GetString("enter customer name");
                    RentalCarOffice.DisplayCustomerOrderDetails(customerName);
                    break;
                }

            case 8:
                {

                    RentalCarOffice.DisplayRentedCars();
                    break;
                }
        }
    }
    catch (Exception ex)
    {

        RentalCarOffice.Error(ex.Message);
    }
}