namespace ConsoleApp1
{
    using System;

    class VirtualPet
    {
        public string PetType { get; }
        public string Name { get; }
        public int Hunger { get; private set; }
        public int Happiness { get; private set; }
        public int Health { get; private set; }

        public VirtualPet(string petType, string name)
        {
            PetType = petType;
            Name = name;
            Hunger = 5;
            Happiness = 5;
            Health = 5;
        }

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine($"Welcome to Virtual Pet Simulator!");
            Console.WriteLine($"You have a {PetType} named {Name}.");
        }

        public void DisplayStats()
        {
            Console.WriteLine($"\nPet Status:");
            Console.WriteLine($"Hunger: {Hunger}/10 | Happiness: {Happiness}/10 | Health: {Health}/10");
        }

        public void CheckStatus()
        {
            if (Hunger <= 1)
                Console.WriteLine("Warning: Your pet is very hungry! Consider feeding.");
            if (Happiness <= 1)
                Console.WriteLine("Warning: Your pet is very unhappy! Consider playing.");
            if (Health <= 1)
                Console.WriteLine("Warning: Your pet's health is very low! Consider resting.");
        }

        public void Feed()
        {
            Hunger = Math.Max(1, Hunger - 2);
            Health = Math.Min(10, Health + 1);
            Console.WriteLine($"{Name} is fed. Hunger decreased, health increased.");
        }

        public void Play()
        {
            Happiness = Math.Min(10, Happiness + 2);
            Hunger = Math.Max(1, Hunger + 1);
            Console.WriteLine($"{Name} is playing. Happiness increased, hunger slightly increased.");
        }

        public void Rest()
        {
            Health = Math.Min(10, Health + 2);
            Happiness = Math.Max(1, Happiness - 1);
            Console.WriteLine($"{Name} is resting. Health increased, happiness slightly decreased.");
        }

        public void TimePasses()
        {
            Hunger = Math.Min(10, Hunger + 1);
            Happiness = Math.Max(1, Happiness - 1);
        }

        public void NeglectConsequences()
        {
            if (Hunger >= 9)
            {
                Health = Math.Max(1, Health - 2);
                Console.WriteLine($"Neglect Warning: {Name} is very hungry. Health decreased!!");
            }
            if (Happiness <= 1)
            {
                Health = Math.Max(1, Health - 1);
                Console.WriteLine($"Neglect Warning: {Name} is very unhappy. Health decreased.");
            }
        }

        public void SpecialEvents()
        {
            if (Hunger >= 9)
                Console.WriteLine($"{Name} has refused to play! It's too hungry.");
            else if (Health <= 2)
                Console.WriteLine($"{Name} is feeling sick. Consider resting to improve health.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Choose a pet type (e.g., cat, dog, rabbit): ");
            string petType = Console.ReadLine();

            Console.Write("Give your pet a name: ");
            string petName = Console.ReadLine();

            VirtualPet pet = new VirtualPet(petType, petName);
            pet.DisplayWelcomeMessage();

            while (true)
            {
                pet.DisplayStats();
                pet.CheckStatus();

                Console.WriteLine("Actions:");
                Console.WriteLine("1. Feed\n2. Play\n3. Rest\n4. Quit");

                Console.Write("Choose an action (1-4): ");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        pet.Feed();
                        break;
                    case "2":
                        pet.Play();
                        break;
                    case "3":
                        pet.Rest();
                        break;
                    case "4":
                        Console.WriteLine("Quitting the game. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                pet.TimePasses();
                pet.NeglectConsequences();
                pet.SpecialEvents();

                System.Threading.Thread.Sleep(1000);  // Simulate 1 hour of time passing
                
            }
        }
    }



}
