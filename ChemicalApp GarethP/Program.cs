using System;
using System.Collections.Generic;
using System.Linq;

class Chemical
{
    public string Name { get; set; }
    public double EfficiencyRating { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Hi-Jean International's chemical efficiency testing program.");

        List<List<Chemical>> efficiencyRatingsLists = new List<List<Chemical>>();

        while (true)
        {
            Console.Write("How many chemicals do you want to test? ");
            int numChemicals = int.Parse(Console.ReadLine());

            List<Chemical> chemicals = new List<Chemical>();

            for (int i = 0; i < numChemicals; i++)
            {
                Console.Write("Enter the name of chemical #" + (i + 1) + ": ");
                string name = Console.ReadLine();

                // Capitalize the first letter of the chemical name if needed
                name = char.ToUpper(name[0]) + name.Substring(1);

                if (chemicals.Any(c => c.Name == name))
                {
                    Console.WriteLine("You cannot test the same chemical twice.");
                    i--;
                    continue;
                }

                Console.Write("Enter the initial germ count 50-100: ");
                double initialCount = double.Parse(Console.ReadLine());

                Console.Write("Enter the final germ count, make sure this is less than the initial germ count: ");
                double finalCount = double.Parse(Console.ReadLine());

                Console.Write("Enter the time taken (in minutes) 5-10 minutes: ");
                double timeTaken = double.Parse(Console.ReadLine());

                double efficiencyRating = (initialCount - finalCount) / timeTaken;
                chemicals.Add(new Chemical { Name = name, EfficiencyRating = efficiencyRating });

                Console.WriteLine("Efficiency rating for " + name + " is " + efficiencyRating);
                Console.WriteLine();
                System.Threading.Thread.Sleep(3000);

            }

            chemicals.Sort((c1, c2) => c2.EfficiencyRating.CompareTo(c1.EfficiencyRating));

            efficiencyRatingsLists.Add(chemicals);

            Console.WriteLine("Most efficient chemicals:");

            for (int i = 0; i < Math.Min(3, numChemicals); i++)
            {
                Chemical chemical = chemicals[i];
                Console.WriteLine(chemical.Name + " has an efficiency rating of " + chemical.EfficiencyRating);
            }

            Console.WriteLine();

            Console.WriteLine("Least efficient chemicals:");

            for (int i = 0; i < Math.Min(3, numChemicals); i++)
            {
                Chemical chemical = chemicals[numChemicals - i - 1];
                Console.WriteLine(chemical.Name + " has an efficiency rating of " + chemical.EfficiencyRating);
            }

            Console.WriteLine();

            Console.Write("Press <enter> if you would like to test more chemicals, or type 'XXX' to exit: ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "XXX")
            {
                for (int i = 0; i < efficiencyRatingsLists.Count; i++)
                {
                    Console.WriteLine("Efficiency ratings for list " + (i + 1) + ":");
                    List<Chemical> efficiencyRatings = efficiencyRatingsLists[i];
                    foreach (Chemical chemical in efficiencyRatings)
                    {
                        Console.WriteLine(chemical.Name + " has an efficiency rating of " + chemical.EfficiencyRating);
                    }
                    Console.WriteLine();
                }

                break;
            }
        }
    }
}