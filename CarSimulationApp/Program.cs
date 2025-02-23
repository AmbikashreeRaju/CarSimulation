class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Auto Driving Car Simulation!");

        while (true)
        {
            Console.WriteLine("Please enter the width and height of the simulation field in x y format:");
            var fieldInput = Console.ReadLine().Split();
            int width = int.Parse(fieldInput[0]);
            int height = int.Parse(fieldInput[1]);

            var field = new Field(width, height);
            var simulation = new Simulation(field);

            while (true)
            {
                Console.WriteLine($"You have created a field of {width} x {height}.");
                Console.WriteLine("Please choose from the following options:");
                Console.WriteLine("[1] Add a car to field");
                Console.WriteLine("[2] Run simulation");

                var option = Console.ReadLine();

                if (option == "1")
                {
                    // Add a new car
                    Console.WriteLine("Please enter the name of the car:");
                    string name = Console.ReadLine();

                    Console.WriteLine($"Please enter initial position of car {name} in x y Direction format:");
                    var position = Console.ReadLine().Split();
                    int x = int.Parse(position[0]);
                    int y = int.Parse(position[1]);
                    string direction = position[2];

                    Console.WriteLine("Please enter the commands for car " + name + ":");
                    string commands = Console.ReadLine();

                    var car = new Car(name, x, y, direction, commands);
                    field.Cars.Add(car);

                    // Show the list of cars
                    Console.WriteLine("Your current list of cars are:");
                    foreach (var carInList in field.Cars)
                    {
                        Console.WriteLine($"- {carInList.Name}, ({carInList.X},{carInList.Y}) {carInList.Direction}, {carInList.Commands}");
                    }
                }
                else if (option == "2")
                {
                    // Run simulation
                    simulation.Run();

                    Console.WriteLine("Please choose from the following options:");
                    Console.WriteLine("[1] Start over");
                    Console.WriteLine("[2] Exit");
                    var restartOption = Console.ReadLine();

                    if (restartOption == "2")
                    {
                        Console.WriteLine("Thank you for running the simulation. Goodbye!");
                        return;
                    }
                    else if (restartOption == "1")
                    {
                        break; // Restart the process
                    }
                }
            }
        }
    }
}