using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace lld_console_app.CarRentalSystem
{
    public class User
    {
        public int UserID { get; set; } 
        public string UserName { get; set; }

        public Reservation Reservation { get; set; }

    }

    public enum VehicleType
    {
        CAR,
        BUS,
        BIKE
    }
    public class Vehicle
    {
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleID { get; set; }
        public VehicleType VechicleType { get; set; }
        public int VehicleHourlyCharge {get; set;}
        public bool IsVehicleBooked {get; set;}
        public Location VehicleLocation {get; set;}

        public Vehicle(int Id, string Name, int HourlyRate)
        {
            this.VehicleID = Id;
            this.VehicleName = Name;
            this.VehicleHourlyCharge = HourlyRate;
        }

        
    }

    public class Store 
    {
        // store has a vehicle inventory
        public int StoreID { get; set; }
        public string StoreName { get; set; }

        public VehicleInventory VehicleInventory { get; set; }

        public List<Reservation> RentalReservations {get; set;}
        public Location StoreLocation {get; set;}

        
    }

    public class VehicleInventory
    {
        // has list of vehicles
    
        // CRUD operations

        public List<Vehicle> Vehicles { get; set; }

        // Add a Vehicle

        public void AddVehicle(Vehicle vehicle)
        {
            if(vehicle != null)
                Vehicles.Add(vehicle);

            // throw error if it already exists
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            if(Vehicles.Contains(vehicle))

                Vehicles.Remove( vehicle);
            else
            {
                Console.WriteLine("Vehicle does not exists. Please try again!");
            }
        }

        public List<Vehicle> GetVehicles()
        {
            return this.Vehicles;
        }


    }

    public enum ReservationStatus 
    {
        PENDING,
        COMPLETED,
        CANCELLED,

    }
    public class Reservation
    {
        public int ReservationID { get; set; }
        public User ReservedUser {get; set;}
        public Vehicle ReservedVehicle {get; set;}
        public ReservationStatus ReservationStatus {get; set;}

    }

    public class Location
    {
        public int LocationName { get; set; }
        public int GeoLocationCode {get; set;}
    }

    public class Bill
    {
        public int BillID { get; set; }
        public Reservation Reservation { get; set; }


    }

    public enum PaymentStatus
    {
        FAILED,
        SUCCESS
    }
    public class Payment
    {
        public int PaymentID { get; set; }
        public Bill BillInfo { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

    public class CarRentalSystem
    {
        public List<Store> Stores { get; set; }
        public List<User> Users { get; set; }

        private static CarRentalSystem _instance;

        private CarRentalSystem()
        {
            this.Users = new List<User>();
            this.Stores = new List<Store>();
        }


        public CarRentalSystem GetInstance()
        {
            if(_instance == null)
            {
                _instance = new CarRentalSystem();
            }
            return _instance;
        }
    }

    public class CarRentalSystemMain
    {
        // TODO: Run the car rental system 

        // should it be a static method?

        public static void Run()
        {
            // set up car rental system

            // Initialize Users


            // Initialize Stores

            // Initialize Vehicles

            // 
            // Make a registration

            // Get the bill

            // Make the payment

            // Complete Reservation
        }
    }

}