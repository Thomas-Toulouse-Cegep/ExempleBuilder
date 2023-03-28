public class Program
{
    // notre interface qui va nous permettre de définir nos sandwichs
    public interface ISandwich
    {
        void SetBread(string bread);

        void SetMeat(string meat);

        void SetCheese(string cheese);

        void SetVegetables(List<string> vegetables);

        public ISandwich withWhiteBread();

        public ISandwich withHam();

        public ISandwich withCheddar();

        public ISandwich withTomato();

        public ISandwich withMayo();

        public ISandwich withKetchup();

        void SetCondiments(List<string> condiments);

        Sandwich GetSandwich();

        Sandwich GetSandwich2();
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
        private Sandwich sandwich;

        private Sandwich sandwich2;

        public SandwichBuilder()
        {
            sandwich = new Sandwich();
            sandwich2 = new Sandwich();
        }

        // méthode 1 pour construction de sandwich

        public void SetBread(string bread)
        {
            sandwich.Bread = bread;
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

        // méthode 2 pour construction de sandwich

        public Sandwich GetSandwich2()
        {
            return sandwich2;
        }

        public ISandwich withWhiteBread()
        {
            sandwich2.Bread = "white bread";
            return this;
        }

        public ISandwich withHam()
        {
            sandwich2.Meat = "ham";

            return this;
        }

        public ISandwich withCheddar()
        {
            sandwich2.Cheese = "Cheddar";

            return this;
        }

        public ISandwich withTomato()
        {
            sandwich2.Vegetables.Add("Onions");

            return this;
        }

        public ISandwich withMayo()
        {
            sandwich2.Condiments.Add("Mayo");
            return this;
        }

        public ISandwich withKetchup()
        {
            sandwich2.Condiments.Add("Ketchup");
            return this;
        }
    }

    public class Cook
    {
        // il y a plusieur méthode de le définir
        public void MakeSandwich(ISandwich sandwichBuilder)
        {
            List<string> vegetables = new List<string>() { "Tomato", "Lettuce" };
            List<string> condiments = new List<string>() { "Mayo" };
            // on peut le définir  avec des get set
            sandwichBuilder.SetBread("white bread");
            sandwichBuilder.SetMeat("Turkey");
            sandwichBuilder.SetCheese("Cheddar");
            sandwichBuilder.SetVegetables(vegetables);
            sandwichBuilder.SetCondiments(condiments);
        }

        public void MakeSandwich2(ISandwich sandwichBuilder)
        {
            // ou un peux utiliser des fonctions qui retourne des les élements du sandwich
            sandwichBuilder.withWhiteBread().withHam().withCheddar().withTomato().withMayo().withKetchup();
        }
    }

    private static void Main(string[] args)
    {
        var sandwichMaker = new Cook();
        var SandwichBuilder = new SandwichBuilder();
        sandwichMaker.MakeSandwich(SandwichBuilder);
        sandwichMaker.MakeSandwich2(SandwichBuilder);
        var sandwichTurkey = SandwichBuilder.GetSandwich();

        // sandwich à la dinde
        Console.WriteLine("Turkey sandwich:");
        Console.WriteLine($"Bread: {sandwichTurkey.Bread}");
        Console.WriteLine($"Meat: {sandwichTurkey.Meat}");
        Console.WriteLine($"Cheese: {sandwichTurkey.Cheese}");
        Console.WriteLine($"Vegetables: {string.Join(", ", sandwichTurkey.Vegetables)}");
        Console.WriteLine($"Condiments: {string.Join(", ", sandwichTurkey.Condiments)}\n");

        // sandwich au jambon
        Console.WriteLine("Ham sandwich:");
        Console.WriteLine($"Bread: {SandwichBuilder.GetSandwich2().Bread}");
        Console.WriteLine($"Meat: {SandwichBuilder.GetSandwich2().Meat}");
        Console.WriteLine($"Cheese: {SandwichBuilder.GetSandwich().Cheese}");
        Console.WriteLine($"Vegetables: {string.Join(", ", SandwichBuilder.GetSandwich2().Vegetables)}");
        Console.WriteLine($"Condiments: {string.Join(", ", SandwichBuilder.GetSandwich2().Condiments)}");
    }
}