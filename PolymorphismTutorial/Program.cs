namespace PolymorphismTutorial
{

    class Program 
    {
        static void Main(string[] args)
        {
            ProductAnotherDerived p = new ProductAnotherDerived();
            Console.WriteLine($"p.GetPrice(): {p.GetPrice()}");
            Console.ReadKey();
        }
    }

    public abstract class ProductBase
    {
        public virtual decimal GetPrice()
        {
            return 10.00m;
        }

        public abstract string GetProductName();
    }

    public class ProductDerived:ProductBase
    {
        public new decimal GetPrice()
        {
            return base.GetPrice() + 2;
        }

        public override string GetProductName()
        {
            return "ProductDerived";
        }
    }

    public class ProductAnotherDerived:ProductDerived
    {
        public new decimal GetPrice()
        {
            return base.GetPrice() + 3;
        }
        public override string GetProductName()
        {
            return "ProductAnotherDerived";
        }
    }
}