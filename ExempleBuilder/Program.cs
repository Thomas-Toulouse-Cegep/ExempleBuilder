public class Program
{
    // notre interface qui va nous permettre de définir nos sandwichs
    public interface ISandwich
    {
        //méthode 2
        public ISandwich withWhiteBread();

        public ISandwich withHam();

        public ISandwich withTurkey();

        public ISandwich withCheddar();

        public ISandwich withTomato();

        public ISandwich withOnions();

        public ISandwich withMayo();

        public ISandwich withKetchup();

        Sandwich GetSandwich();
    }

    // pour les get set
    public class Sandwich
    {
        // nos élements du sandwich
        public string Bread { get; set; }

        public string Meat { get; set; }
        public string Cheese { get; set; }
        public List<string> Vegetables { get; set; }
        public List<string> Condiments { get; set; }

        public Sandwich()
        {
            Vegetables = new List<string>();
            Condiments = new List<string>();
        }
    }

    public class SandwichBuilder : ISandwich
    {
        // ce qui vas nous permettre de construire le sandwich

        private Sandwich sandwich = new Sandwich();

        public Sandwich GetSandwich()
        {
            return sandwich;
        }

        // méthode 2 pour construction de sandwich

        public ISandwich withWhiteBread()
        {
            sandwich.Bread = "white bread";
            return this;
        }

        public ISandwich withHam()
        {
            sandwich.Meat = "ham";

            return this;
        }

        public ISandwich withCheddar()
        {
            sandwich.Cheese = "Cheddar";

            return this;
        }

        public ISandwich withTomato()
        {
            sandwich.Vegetables.Add("Tomato");

            return this;
        }

        public ISandwich withMayo()
        {
            sandwich.Condiments.Add("Mayo");
            return this;
        }

        public ISandwich withKetchup()
        {
            sandwich.Condiments.Add("Ketchup");
            return this;
        }

        public ISandwich withTurkey()
        {
            sandwich.Meat = "Turkey";

            return this;
        }

        public ISandwich withOnions()
        {
            sandwich.Vegetables.Add("Onions");

            return this;
        }
    }

    public class SandwichBuilder2 : ISandwich
    {
        // ce qui vas nous permettre de construire le sandwich

        private Sandwich sandwich = new Sandwich();

        public Sandwich GetSandwich()
        {
            return sandwich;
        }

        // méthode 2 pour construction de sandwich

        public ISandwich withWhiteBread()
        {
            sandwich.Bread = "white bread";
            return this;
        }

        public ISandwich withHam()
        {
            sandwich.Meat = "ham";

            return this;
        }

        public ISandwich withCheddar()
        {
            sandwich.Cheese = "Cheddar";

            return this;
        }

        public ISandwich withOnions()
        {
            sandwich.Vegetables.Add("Onions");

            return this;
        }

        public ISandwich withMayo()
        {
            sandwich.Condiments.Add("Mayo");
            return this;
        }

        public ISandwich withKetchup()
        {
            sandwich.Condiments.Add("Ketchup");
            return this;
        }

        public ISandwich withTurkey()
        {
            sandwich.Meat = "Turkey";

            return this;
        }

        public ISandwich withTomato()
        {
            sandwich.Vegetables.Add("Tomato");

            return this;
        }
    }

    public class Cook
    {
        // il y a plusieur méthode de le définir
        public void MakeSandwich(ISandwich sandwichBuilder)
        {
            sandwichBuilder.withWhiteBread().withHam().withCheddar().withTomato().withMayo();
        }

        public void MakeSandwichTurkey(ISandwich sandwichBuilder)
        {
            sandwichBuilder.withWhiteBread().withTurkey().withCheddar().withTomato().withOnions().withMayo().withKetchup();
        }
    }

    private static void Main(string[] args)
    {
        var sandwichMaker = new Cook();
        var SandwichBuilder = new SandwichBuilder();
        var SandwichBuilder2 = new SandwichBuilder2();
        sandwichMaker.MakeSandwich(SandwichBuilder);
        sandwichMaker.MakeSandwichTurkey(SandwichBuilder2);
        Console.WriteLine("Ham Sandwich:");
        Console.WriteLine($"Bread: {SandwichBuilder.GetSandwich().Bread}");
        Console.WriteLine($"Meat: {SandwichBuilder.GetSandwich().Meat}");
        Console.WriteLine($"Cheese: {SandwichBuilder.GetSandwich().Cheese}");
        Console.WriteLine($"Vegetables: {string.Join(", ", SandwichBuilder.GetSandwich().Vegetables)}");
        Console.WriteLine($"Condiments: {string.Join(", ", SandwichBuilder.GetSandwich().Condiments)}\n");

        sandwichMaker.MakeSandwichTurkey(SandwichBuilder);

        // sandwich à la dinde
        Console.WriteLine("Turkey Sandwich:");
        Console.WriteLine($"Bread: {SandwichBuilder2.GetSandwich().Bread}");
        Console.WriteLine($"Meat: {SandwichBuilder2.GetSandwich().Meat}");
        Console.WriteLine($"Cheese: {SandwichBuilder2.GetSandwich().Cheese}");
        Console.WriteLine($"Vegetables: {string.Join(", ", SandwichBuilder2.GetSandwich().Vegetables)}");
        Console.WriteLine($"Condiments: {string.Join(", ", SandwichBuilder2.GetSandwich().Condiments)}\n");
    }
}