using System.Runtime.InteropServices;

public class Program
{
    public interface ISandwich
    {
        void SetBread(string bread);

        void SetMeat(string meat);

        void SetCheese(string cheese);

        void SetVegetables(List<string> vegetables);

        public ISandwich withWhiteBread();

        public ISandwich Ham();

        void SetCondiments(List<string> condiments);

        Sandwich GetSandwich();
    }

    public class Sandwich
    {
        public string Bread { get; set; }
        public string Meat { get; set; }
        public string Cheese { get; set; }
        public List<string> Vegetables { get; set; }
        public List<string> Condiments { get; set; }
    }

    public class JambonSandwichBuilder : ISandwich
    {
        private Sandwich sandwich;

        public JambonSandwichBuilder()
        {
            sandwich = new Sandwich();
        }

        public void SetBread(string bread)
        {
            sandwich.Bread = bread;
        }

        public ISandwich withWhiteBread()
        {
            sandwich.Bread = "white bread";
            return this;
        }

        public ISandwich Ham()
        {
            sandwich.Meat = "ham";

            return this;
        }

        public void SetMeat(string meat)
        {
            sandwich.Meat = meat;
        }

        public void SetCheese(string cheese)
        {
            sandwich.Cheese = cheese;
        }

        public void SetVegetables(List<string> vegetables)
        {
            sandwich.Vegetables = vegetables;
        }

        public void SetCondiments(List<string> condiments)
        {
            sandwich.Condiments = condiments;
        }

        public Sandwich GetSandwich()
        {
            return sandwich;
        }
    }

    public class SandwichMaker
    {
        public void MakeSandwich(ISandwich sandwichBuilder)
        {
            sandwichBuilder.SetBread("white bread");
            sandwichBuilder.SetMeat("Turkey");
            sandwichBuilder.SetCheese("Cheddar");
            sandwichBuilder.SetVegetables(new List<string>() { "Lettuce", "Tomato" });
            sandwichBuilder.SetCondiments(new List<string>() { "Mayo", "Mustard" });
        }

        public void makesan(ISandwich sandwichBuilder)
        {
            sandwichBuilder.withWhiteBread().Ham();
        }
    }

    private static void Main(string[] args, SandwichMaker sandwichMaker)
    {
        //var sandwichMaker = new SandwichMaker();
        var JambonSandwichBuilder = new JambonSandwichBuilder();
        sandwichMaker.MakeSandwich(JambonSandwichBuilder);
        var sandwich = JambonSandwichBuilder.GetSandwich();
        var i = sandwichMaker.makesan();
        Console.WriteLine("Turkey sandwich:");
        Console.WriteLine($"Bread: {sandwich.Bread}");
        Console.WriteLine($"Meat: {sandwich.Meat}");
        Console.WriteLine($"Cheese: {sandwich.Cheese}");
        Console.WriteLine($"Vegetables: {string.Join(", ", sandwich.Vegetables)}");
        Console.WriteLine($"Condiments: {string.Join(", ", sandwich.Condiments)}");
    }
}