public class Simulation
{
    private Field field;

    public Simulation(Field field)
    {
        this.field = field;
    }

    // Run the simulation by processing all car commands step by step
    public void Run()
    {
        int step = 0;
        bool collisionOccurred = false;

        // Run the simulation until all cars have either moved or collided
        while (true)
        {
            bool allCarsProcessed = true;

            // Process commands for each car
            for (int i = 0; i < field.Cars.Count; i++)
            {
                var car = field.Cars[i];

                // Skip cars that have already collided
                if (car.Collided) continue;

                // Check if the car has commands to process
                if (step < car.Commands.Length)
                {
                    allCarsProcessed = false;
                    var command = car.Commands[step];
                    car.ExecuteCommand(command);

                    // Undo move if car goes out of bounds
                    if (field.IsOutOfBounds(car))
                    {
                        var (prevX, prevY) = car.GetPosition();
                        car.X = prevX;
                        car.Y = prevY;
                    }
                }
            }
			
			step++;

            // Check for collisions after each step
            var collisions = field.CheckCollision();
            if (collisions.Count > 0)
            {
                Console.WriteLine("After simulation, the result is:");
                foreach (var collidedCar in collisions)
                {
                    Console.WriteLine($"{collidedCar.Name}, collides with another car at ({collidedCar.X},{collidedCar.Y}) at step {step}");
                }
                collisionOccurred = true;
                break; // End the simulation if there is a collision
            }            

            // If all cars have either processed their commands or collided, end the simulation
            if (allCarsProcessed || field.Cars.All(car => car.Collided))
            {
                break;
            }
        }

        // Print final result if there was no collision
        if (!collisionOccurred)
        {
            Console.WriteLine("After simulation, the result is:");
            foreach (var car in field.Cars)
            {
                Console.WriteLine($"{car.Name}, ({car.X},{car.Y}) {car.Direction}");
            }
        }
    }
}