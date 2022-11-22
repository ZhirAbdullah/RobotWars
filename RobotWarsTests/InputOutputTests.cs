using Moq;
using RobotWars;
using Shouldly;

namespace RobotWarsTests
{
    public class InputOutputTests
    {
        [Fact]
        public void WhenRobotIsOutOfBounds_ThenShowOutOfBoundsMessage()
        {
            // Arrange
            var mockValidation = new Mock<IValidation>();
            var inputOutput = new InputOutput(mockValidation.Object);
            var robot = SampleRobot();
            robot.OutOfBounds = true;
            // Act
            var response = inputOutput.OutputRobotPositions(robot, 1);

            //Assert
            response.ShouldBe("Robot 1 is out of bounds");
        }
        [Fact]
        public void WhenRobotIsWithinTheArena_ThenShowFinalPosition()
        {
            // Arrange
            var mockValidation = new Mock<IValidation>();
            var inputOutput = new InputOutput(mockValidation.Object);
            // Act
            var response = inputOutput.OutputRobotPositions(SampleRobot(), 1);

            //Assert
            response.ShouldBe("12N");
        }

        private Robot SampleRobot()
        {
            return new Robot
            {
                OutOfBounds = false,
                FinalPosition = "12N",
                Orientation = Orientation.North,
                X = 1,
                Y = 2
            };
        }
    }
}