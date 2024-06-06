using System.Linq;

namespace CSharpInheritanceExample;

class Program
{
    static void Main(string[] args)
    {
        Product desk = new Desk();
        ((Desk)desk).ImportTaxPercentage = 2;
        desk.Price = 100;
        desk.Add();
        desk.Add();

        Console.WriteLine($"Total value of desks in stock: {desk.GetTotalValueInStock()}");

        Product droneTurbo = new TurboDrone();
        droneTurbo.Price = 200;
        ((Drone)droneTurbo).QuantityIncremented = 10;
        droneTurbo.Add();
        droneTurbo.Add();

        Product droneStandard = new StandardDrone();
        droneStandard.Price = 150;
        ((Drone)droneStandard).QuantityIncremented = 5;
        droneStandard.Add();
        droneStandard.Add();
        droneStandard.Add();

        Product[] products = new Product[3];
        products[0] = desk;
        products[1] = droneStandard;
        products[2] = droneTurbo;

        Console.WriteLine();
        Console.WriteLine("Stock Inventory Report");
        Console.WriteLine("______________________");
        Console.WriteLine();

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine();
        decimal grandTotalStockValue = products.Sum(p=>p.GetTotalValueInStock());
        Console.WriteLine($"Grand total value of all products in stock: {grandTotalStockValue}");
        Console.ReadKey();
    }

    public class TurboDrone:Drone
    {
        public override string ProductName 
        {
            get 
            {
                return "Turbo Drone";
            }
        }

    }

    public class StandardDrone:Drone 
    {
        public override string ProductName 
        {
            get 
            {
                return "Standard Drone";
            }
        }

    }

    public class Drone:Product
    {
        public int QuantityIncremented {get;set;}
        public override string ProductName 
        {
            get 
            {
                return "Drone";
            }
        }
        public Drone()
        {
            QuantityIncremented = 1;
        }
        public override void Add()
        {
            _quantity = _quantity + QuantityIncremented;
        }
    }

    public class Desk:Product
    {
        public decimal ImportTaxPercentage {get;set;}
        public override string ProductName 
        { 
            get 
            {
                return "Desk";
            } 
        }
        public Desk()
        {

        }

        public override decimal GetTotalValueInStock()
        {
            decimal netTotal = base.GetTotalValueInStock() - (base.GetTotalValueInStock()*(ImportTaxPercentage/100));

            return netTotal;
        }
    }

    public abstract class Product
    {
        protected int _quantity = 0;
        public decimal Price {get;set;}
        public Product()
        {

        }

        public abstract string ProductName {get;}

        public virtual void Add()
        {
            _quantity++;
        }

        public void Remove()
        {
            if(_quantity>0)
            {
                _quantity--;
            }
        }

        public virtual decimal GetTotalValueInStock()
        {
            return _quantity*Price;
        }

        public override string ToString()
        {
            return $"Product Name: {ProductName}, Price: {Price}, Quantity:{_quantity}, Total Value:{GetTotalValueInStock()}";
        }

    }

}