public class Field
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Car> Cars { get; set; } = new List<Car>();

    // Constructor to initialize the field dimensions
    public Field(int width, int height)
    {
        Width = width;
        Height = height;
    }

    // Method to check if a car is out of bounds
    public bool IsOutOfBounds(Car car)
    {
        return car.X < 0 || car.Y < 0 || car.X >= Width || car.Y >= Height;
    }

    // Check for collisions between cars
    public List<Car> CheckCollision()
    {
        var collidedCars = new List<Car>();
        for (int i = 0; i < Cars.Count; i++)
        {
            for (int j = i + 1; j < Cars.Count; j++)
            {
                if (Cars[i].X == Cars[j].X && Cars[i].Y == Cars[j].Y && !Cars[i].Collided && !Cars[j].Collided)
                {
                    Cars[i].Collided = true;
                    Cars[j].Collided = true;
                    collidedCars.Add(Cars[i]);
                    collidedCars.Add(Cars[j]);
                }
            }
        }
        return collidedCars;
    }
}