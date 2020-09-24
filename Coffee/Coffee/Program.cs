using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee
{
    class Program
    {
        static void Main(string[] args)
        {
            Person client = new Person("Rebe");
            Americano americano = new Americano("Americano", "black");
            CoffeeMachine first = new CoffeeMachine(americano,
                new Grinder("medium"),
                new WaterTank("small", "square"));
            Expresso expresso = new Expresso("Expresso", "light");
            CoffeeMachine second = new CoffeeMachine(expresso,
                new Grinder("fine"),
                new WaterTank("big", "sphere"));

            client.Order(first);
            client.Order(second);

            Console.ReadKey();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public void Order(CoffeeMachine coffee)
        {
            Console.WriteLine($"{this.Name} ordered an {coffee.coffee.Name} {coffee.coffee.Type} Coffee" +
                $" which has to be {coffee.grinder.Size} grinded " +
                $" using a {coffee.tank.Size} {coffee.tank.Form} water tank.");

            coffee.MakeCoffee();
        }
    }

    public class CoffeeMachine
    {
        public Coffee coffee { get; set; }
        public Grinder grinder { get; set; }
        public WaterTank tank { get; set; }
        
        public CoffeeMachine(Coffee type, Grinder grinder, WaterTank tank)
        {
            this.coffee = type;
            this.grinder = grinder;
            this.tank = tank;
        }

        public CoffeeMachine() { }

        public void MakeCoffee()
        {
            this.Grind();
            this.Done();
            Console.WriteLine();
        }

        public void Grind()
        {
            Console.WriteLine($"{this.coffee.Name} Coffee is being {this.grinder.Size} grinded...");
        }

        public void Done()
        {
            Console.WriteLine("Your Coffee is ready!");
        }
    }

    public abstract class Coffee
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Coffee(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }
    }

    public class Americano : Coffee
    {
        public Americano(string name, string taste) : base(name, taste)
        {

        }
    }

    public class Expresso : Coffee
    {
        public Expresso(string name, string taste) : base(name, taste)
        {

        }
    }

    public class Grinder
    {
        public string Size { get; set; }
        
        public Grinder(string size)
        {
            this.Size = size;
        }
    }

    public class WaterTank
    {
        public string Size { get; set; }
        public string Form { get; set; }

        public WaterTank(string size, string form)
        {
            this.Size = size;
            this.Form = form;
        }
    }
}
