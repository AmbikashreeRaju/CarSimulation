using NUnit.Framework;


namespace CarSimulationTests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            // Initialize a car before each test
            car = new Car("A", 1, 1, "N", "FFR");
        }

        [Test]
        public void Car_Should_Initialize_Correctly()
        {
            // Assert the initial state of the car
            Assert.AreEqual("A", car.Name);
            Assert.AreEqual(1, car.X);
            Assert.AreEqual(1, car.Y);
            Assert.AreEqual("N", car.Direction);
            Assert.AreEqual("FFR", car.Commands);
            Assert.IsFalse(car.Collided);
        }

        [Test]
        public void Car_Should_TurnLeft_Correctly()
        {
            // Test car turning left
            car.ExecuteCommand('L');
            Assert.AreEqual("W", car.Direction); // Facing West after turning left from North

            car.ExecuteCommand('L');
            Assert.AreEqual("S", car.Direction); // Facing South after turning left from West

            car.ExecuteCommand('L');
            Assert.AreEqual("E", car.Direction); // Facing East after turning left from South

            car.ExecuteCommand('L');
            Assert.AreEqual("N", car.Direction); // Facing North after turning left from East
        }

        [Test]
        public void Car_Should_TurnRight_Correctly()
        {
            // Test car turning right
            car.ExecuteCommand('R');
            Assert.AreEqual("E", car.Direction); // Facing East after turning right from North

            car.ExecuteCommand('R');
            Assert.AreEqual("S", car.Direction); // Facing South after turning right from East

            car.ExecuteCommand('R');
            Assert.AreEqual("W", car.Direction); // Facing West after turning right from South

            car.ExecuteCommand('R');
            Assert.AreEqual("N", car.Direction); // Facing North after turning right from West
        }

        [Test]
        public void Car_Should_MoveForward_Correctly()
        {
            // Test car moving forward in different directions
            car.ExecuteCommand('F');
            Assert.AreEqual(1, car.X);
            Assert.AreEqual(2, car.Y); // Moves forward to (1,2) when facing North

            car = new Car("A", 1, 1, "S", "F");
            car.ExecuteCommand('F');
            Assert.AreEqual(1, car.X);
            Assert.AreEqual(0, car.Y); // Moves forward to (1,0) when facing South

            car = new Car("A", 1, 1, "E", "F");
            car.ExecuteCommand('F');
            Assert.AreEqual(2, car.X);
            Assert.AreEqual(1, car.Y); // Moves forward to (2,1) when facing East

            car = new Car("A", 1, 1, "W", "F");
            car.ExecuteCommand('F');
            Assert.AreEqual(0, car.X);
            Assert.AreEqual(1, car.Y); // Moves forward to (0,1) when facing West
        }

        [Test]
        public void Car_Should_Ignore_Command_When_Collided()
        {
            // Set the car as collided
            car.Collided = true;
            var initialPosition = car.GetPosition();

            // Try executing a command while the car has collided
            car.ExecuteCommand('F');
            car.ExecuteCommand('L');
            car.ExecuteCommand('R');

            // Ensure the car's position hasn't changed
            Assert.AreEqual(initialPosition, car.GetPosition());
        }

        [Test]
        public void Car_Should_Handle_Complete_Command_Sequence_Correctly()
        {
            // Test a complete sequence of commands
            car.ExecuteCommand('F');  // Move to (1, 2)
            car.ExecuteCommand('F');  // Move to (1, 3)
            car.ExecuteCommand('R');  // Turn to East
            car.ExecuteCommand('F');  // Move to (2, 3)

            Assert.AreEqual((2, 3), car.GetPosition());
            Assert.AreEqual("E", car.Direction);
        }
    }
}
