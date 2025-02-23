using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CarSimulationTests
{
    [TestFixture]
    public class FieldTests
    {
        private Field _field;

        [SetUp]
        public void SetUp()
        {
            // Create a field with width 5 and height 5
            _field = new Field(5, 5);
        }

        [Test]
        public void Car_ShouldBeOutOfBounds_WhenOutsideField()
        {
            var car = new Car("Car1", 0, 0, "N", "");
            _field.Cars.Add(car);

            // Move car out of bounds
            car.X = -1;
            Assert.IsTrue(_field.IsOutOfBounds(car));

            car.Y = -1;
            Assert.IsTrue(_field.IsOutOfBounds(car));

            car.X = 6;
            Assert.IsTrue(_field.IsOutOfBounds(car));

            car.Y = 6;
            Assert.IsTrue(_field.IsOutOfBounds(car));
        }

        [Test]
        public void Car_ShouldNotBeOutOfBounds_WhenInsideField()
        {
            var car = new Car("Car1", 2, 2, "N", "");
            _field.Cars.Add(car);

            Assert.IsFalse(_field.IsOutOfBounds(car));

            car.X = 4;
            car.Y = 4;
            Assert.IsFalse(_field.IsOutOfBounds(car));
        }

        [Test]
        public void Field_ShouldDetectCollision_WhenCarsOverlap()
        {
            var car1 = new Car("Car1", 2, 2, "N", "");
            var car2 = new Car("Car2", 2, 2, "S", "");
            _field.Cars.Add(car1);
            _field.Cars.Add(car2);

            var collidedCars = _field.CheckCollision();

            Assert.AreEqual(2, collidedCars.Count);
            Assert.IsTrue(car1.Collided);
            Assert.IsTrue(car2.Collided);
        }

        [Test]
        public void Field_ShouldNotDetectCollision_WhenCarsDoNotOverlap()
        {
            var car1 = new Car("Car1", 2, 2, "N", "");
            var car2 = new Car("Car2", 3, 3, "S", "");
            _field.Cars.Add(car1);
            _field.Cars.Add(car2);

            var collidedCars = _field.CheckCollision();

            Assert.AreEqual(0, collidedCars.Count);
            Assert.IsFalse(car1.Collided);
            Assert.IsFalse(car2.Collided);
        }

        [Test]
        public void Car_ShouldMoveCorrectly_WhenExecuteCommandIsCalled()
        {
            var car = new Car("Car1", 2, 2, "N", "F");
            _field.Cars.Add(car);

            // Execute the "F" (Move Forward) command
            car.ExecuteCommand('F');

            // After moving forward, the car should be at position (2, 3)
            var (x, y) = car.GetPosition();
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);
        }

        [Test]
        public void Car_ShouldTurnLeft_WhenExecuteLeftCommandIsCalled()
        {
            var car = new Car("Car1", 2, 2, "N", "L");
            _field.Cars.Add(car);

            // Execute the "L" (Turn Left) command
            car.ExecuteCommand('L');

            // After turning left, the car's direction should be "W"
            Assert.AreEqual("W", car.Direction);
        }

        [Test]
        public void Car_ShouldTurnRight_WhenExecuteRightCommandIsCalled()
        {
            var car = new Car("Car1", 2, 2, "N", "R");
            _field.Cars.Add(car);

            // Execute the "R" (Turn Right) command
            car.ExecuteCommand('R');

            // After turning right, the car's direction should be "E"
            Assert.AreEqual("E", car.Direction);
        }

        [Test]
        public void Car_ShouldNotMove_WhenCollided()
        {
            var car1 = new Car("Car1", 2, 2, "N", "F");
            var car2 = new Car("Car2", 2, 2, "S", "F");
            _field.Cars.Add(car1);
            _field.Cars.Add(car2);

            // Both cars should collide
            _field.CheckCollision();

            // Car1 should not move because it collided
            var (x1, y1) = car1.GetPosition();
            Assert.AreEqual(2, x1);
            Assert.AreEqual(2, y1);

            // Car2 should not move because it collided
            var (x2, y2) = car2.GetPosition();
            Assert.AreEqual(2, x2);
            Assert.AreEqual(2, y2);
        }
    }
}
