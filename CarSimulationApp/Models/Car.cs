public class Car
{
    public string Name { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string Direction { get; set; } // N, S, E, W
    public string Commands { get; set; }
    public bool Collided { get; set; } = false;

    // Initialize car with position, direction, and commands
    public Car(string name, int x, int y, string direction, string commands)
    {
        Name = name;
        X = x;
        Y = y;
        Direction = direction;
        Commands = commands;
    }

    // Method to execute a single command
    public void ExecuteCommand(char command)
    {
        if (Collided) return;

        switch (command)
        {
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
            case 'F':
                MoveForward();
                break;
        }
    }

    private void TurnLeft()
    {
        // Update direction when turning left
        Direction = Direction switch
        {
            "N" => "W",
            "S" => "E",
            "E" => "N",
            "W" => "S",
            _ => Direction
        };
    }

    private void TurnRight()
    {
        // Update direction when turning right
        Direction = Direction switch
        {
            "N" => "E",
            "S" => "W",
            "E" => "S",
            "W" => "N",
            _ => Direction
        };
    }

    private void MoveForward()
    {
        // Move car one step based on its direction
        if (Direction == "N") Y++;
        if (Direction == "S") Y--;
        if (Direction == "E") X++;
        if (Direction == "W") X--;
    }

    // Method to get the car's position
    public (int, int) GetPosition() => (X, Y);
}