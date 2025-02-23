using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSimulationTests
{
    [TestFixture]
    public class SimulationTests
    {
        private Field _field;
        private Simulation _simulation;

        [SetUp]
        public void SetUp()
        {
            // Set up a field with dimensions 5x5
            _field = new Field(5, 5);
        }

        [Test]
        public void Simulation_ShouldProcessCommandsCorrectly()
        {
            // Arrange: Add a car at position (0, 0) facing North, with commands to move forward
            var car = new Car("Car1", 0, 0, "N", "FF");
            _field.Cars.Add(car);
            _simulation = new Simulation(_field);

            // Act: Run the simulation
            _simulation.Run();

            // Assert: Car should have moved to position (0, 2) after executing the commands
            var (x, y) = car.GetPosition();
            Assert.AreEqual(0, x);
            Assert.AreEqual(2, y);
        }

        [Test]
        public void Simulation_ShouldHandleCollision_WhenCarsOverlap()
        {
            // Arrange: Add two cars at position (2, 2) with commands to move forward
            var car1 = new Car("Car1", 2, 2, "N", "FFFLLFF");
            var car2 = new Car("Car2", 2, 2, "S", "FLLFFFF");
            _field.Cars.Add(car1);
            _field.Cars.Add(car2);
            _simulation = new Simulation(_field);

            // Act: Run the simulation
            _simulation.Run();

            // Assert: Both cars should have collided at position (2, 2)
            Assert.IsTrue(car1.Collided);
            Assert.IsTrue(car2.Collided);
        }

        [Test]
        public void Simulation_ShouldStop_WhenCollisionOccurs()
        {
            // Arrange: Add two cars at position (2, 2) with commands to move forward
            var car1 = new Car("Car1", 2, 2, "N", "F");
            var car2 = new Car("Car2", 2, 2, "S", "F");
            _field.Cars.Add(car1);
            _field.Cars.Add(car2);
            _simulation = new Simulation(_field);

            // Act: Run the simulation
            _simulation.Run();

            // Assert: The simulation should stop after the collision
            var collisionMessage = $"After simulation, the result is:\n" +
                                   $"Car1, collides with another car at (2,2) at step 1\n" +
                                   $"Car2, collides with another car at (2,2) at step 1\n";
            // Check the console output for the collision message
            Assert.AreEqual(collisionMessage, GetConsoleOutput());
        }

        [Test]
        public void Simulation_ShouldRevertCar_WhenOutOfBounds()
        {
            // Arrange: Add a car at position (0, 0) facing North, with commands to move forward twice
            var car = new Car("Car1", 1, 2, "N", "FFRFFFFRRL");
            _field.Cars.Add(car);
            _simulation = new Simulation(_field);

            // Act: Run the simulation
            _simulation.Run();

            // Assert: The car should not have moved out of bounds
            var (x, y) = car.GetPosition();
            Assert.AreEqual(0, x);
            Assert.AreEqual(1, y); // It should have moved to (0, 1) instead of (0, 2)
        }

        [Test]
        public void Simulation_ShouldFinish_WhenAllCarsProcessed()
        {
            // Arrange: Add a car at position (0, 0) facing North, with commands to move forward
            var car = new Car("Car1", 0, 0, "N", "FFLFF");
            _field.Cars.Add(car);
            _simulation = new Simulation(_field);

            // Act: Run the simulation
            _simulation.Run();

            // Assert: The simulation should finish as the car processes all commands
            var (x, y) = car.GetPosition();
            Assert.AreEqual(0, x);
            Assert.AreEqual(1, y); // Car should have moved forward to (0, 1)
        }

        private string GetConsoleOutput()
        {
            // Capture console output (needed to verify output in simulation)
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                _simulation.Run();
                return sw.ToString();
            }
        }
    }
}
