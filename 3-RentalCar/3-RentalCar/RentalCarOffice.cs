using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_RentalCar;
public abstract class RentalCarOffice
{
    static List<Car> _cars = new();
    static List<Customer> _customers = new();
    static List<CarRental> _carRental = new();

    public static void AddNewCar(string name, string manufacturedYear,
        decimal dailyRent, string manufactureCountry)
    {
        int id = CreateId(_cars);
        Sedan sadan = new(id, name, manufacturedYear, dailyRent, manufactureCountry);
        _cars.Add(sadan);
        Success();
    }



    public static void AddNewCar(string name, string manufacturedYear,
        decimal dailyRent, string manufactureCountry, int Capacity)
    {
        int id = CreateId(_cars);
        PickupTruck pickupTruck = new(Capacity, id, name, manufacturedYear, dailyRent, manufactureCountry);
        _cars.Add(pickupTruck);
        Success();


    }
    
    public static void ShowTruck()
    {
        var items = _cars.Where(c => c is PickupTruck).ToList();


        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (PickupTruck truck in items)
            Console.WriteLine($" name:{truck.Name} model:{truck.ManufacturedYear} capacity: {truck.Capacity}" +
                $"Daily rent price: {truck.DailyRentPrice}" +
                $" status: { truck.status} ");
        Console.ResetColor();
    }

    public static void ShowSedan()
    {
        var items = _cars.Where(c => c is Sedan).ToList();

        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (Sedan sedan in items)
            Console.WriteLine($" name: {sedan.Name} model: {sedan.ManufacturedYear} " +
                $"daily rent price: {sedan.DailyRentPrice} status: { sedan.status}");
        Console.ResetColor();
    }

    public static void DisplayCarDetails(string carName)
    {
        var car = _cars.Find(_ => _.Name == carName);
        if (car != null)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            car.Details();
            Console.ResetColor();
        }

        else
        {
            throw new Exception("car not found");
        }
    }

    public static void AddNewCostumer(string name, string mobile)
    {
        bool customerIsExist = IsCustomerExist(mobile);
        if (customerIsExist != true)
        {
            int id = CreateId(_customers);
            Customer customer = new Customer(id, name, mobile);
            _customers.Add(customer);
            Success();
        }
        else
        {
            throw new Exception("this customer already  has been registred");
        }

    }

    public static bool IsCustomerExist(string mobile)
    {
        bool result = false;
        var customer = _customers.FirstOrDefault(x => x.Mobile == mobile);
        if (customer != null)
        {
            result = true;
        }
        return result;
    }

    public static void RentCar(string customerName, string carName, int rentalDays)
    {
        var customer = _customers.FirstOrDefault(_ => _.Name == customerName);
        if (customer != null)
        {
            var car = _cars.FirstOrDefault(_ => _.Name == carName && _.status == Status.NotRented);
            if (car != null)
            {
                int id = CreateId(_carRental);
                CarRental rentalCar = new(id, customerName, carName, rentalDays, car.DailyRentPrice);
                _carRental.Add(rentalCar);
                Success();
                car.ChangeStatusToReterned();
            }
            else
            {
                throw new Exception("car not found or It has already been rented.");
            }
        }
        else
        {
            throw new Exception("customer dose not registered");
        }
    }

    public static Car GetCarByName(string carName)
    {

        var car = _cars.Find(_ => _.Name == carName);
        if (car != null)
        {
            return car;
        }
        
        return null;
    }

    public static void EditDailyRentPrice(string carName,decimal newDailyRentPrice)
    {
        var car = _cars.Find(_ => _.Name == carName);
        if(car!=null)
        {
            car.EditDailyRentPrice(newDailyRentPrice);
            Success();
        }
        else
        {
            throw new Exception("car not found");
        }
    }
   
    public static void DisplayCustomerOrderDetails(string name)
    {
        var customer = _customers.Find(c => c.Name == name);
        if (customer!=null)
        {
            var userOrder = _carRental.Where(c => c.UserName == name).ToList();
            if (userOrder.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var order in userOrder)
                {
                    Console.WriteLine($"{order.UserName}\n" +
                        $"\t car name:{order.CarName}\n" +
                        $"\t order date:{order.OrderDate.DayOfWeek}{order.OrderDate}\n" +
                        $"\t number of days rented: {order.RentalDays}\n" +
                        $"\t return date: {order.ReturnDate.DayOfWeek}{order.ReturnDate}\n" +
                        $"\t the amount payable: {order.TotalPrice}");
                }
                Console.ResetColor();
            }
            else
            {
                throw new Exception("This customer has no orders yet ");
            }
        }
        else
        {
            throw new Exception("customer not found");
        }
    }
    public static void DisplayRentedCars()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (var car in _carRental)
        {
            Console.WriteLine($"{car.CarName}\n" +
                $"\t customer: {car.UserName}\n" +
                $"\t order date:{car.OrderDate.DayOfWeek}{car.OrderDate}\n"+
                $"\t return date: {car.ReturnDate.DayOfWeek}{car.ReturnDate}\n");
        }
        Console.ResetColor();
    }
    
    
    
    public static int Run()
    {
        Console.WriteLine($"choice an option\n" +
            $"1: Add New Car\n" +
            $"2: Add New Customer\n" +
            $"3: Rent A Car\n" +
            $"4: Display Car Details\n" +
            $"5: Display All cars\n" +
            $"6: Edit daily rent price\n" +
            $"7: Display Customer's Order details\n" +
            $"8: Display List of rented cars\n " +
            $"0: Exit");
        int value = int.Parse(Console.ReadLine()!);
        return value;
    }
    public static string GetString(string message)
    {
        Console.WriteLine(message);
        string value = Console.ReadLine()!;
        return value;
    }
    public static DateOnly GetDate(string message)
    {

        Console.WriteLine(message);
        DateOnly value = DateOnly.Parse(Console.ReadLine()!);
        return value;
    }
    public static int GetInteger(string message)
    {
        Console.WriteLine(message);

        int value = int.Parse(Console.ReadLine()!);
        return value;
    }
    public static int CreateId<T>(List<T> list)
    {
        int value = 1;
        if (list is List<Car>)
        {
            if (list.Count > 0)
                value = list.Count + 1;
        }
        else if (list is List<Sedan>)
        {
            value = list.Count + 1;
        }
        else if (list is List<PickupTruck>)
        {
            value = list.Count + 1;
        }
        else if (list is List<Customer>)
        {
            value = list.Count + 1;
        }
        else if (list is List<CarRental>)
        {
            value = list.Count + 1;
        }
        return value;
    }
    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"------------\n{message}\n-----------");
        Console.ResetColor();
    }
    public static void Success()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"-------------\nSuccess full\n-------------");
        Console.ResetColor();

    }
}