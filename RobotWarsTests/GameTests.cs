using Moq;
using RobotWars;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWarsTests
{
    public class GameTests
    {

        [Fact]
        public void GivenRobotAndInstructions_ThenReturnFinalPosition()
        {
            //Arrange
            var mockValidation = new Mock<IValidation>();
            var mockInputOutput = new Mock<IInputOutput>();
            var game = new Game(mockInputOutput.Object);

            var robot = SampleRobotWithInstruction();
            robot.Instructions = "MMLMRMRM";

            // Act
            var responseRobot = game.CommenceGame(SampleArena(), robot);

            //Assert
            responseRobot.OutOfBounds.ShouldBe(false);
            responseRobot.FinalPosition.ShouldBe("58E");
        }

        [Fact]
        public void GivenRobotAndInstructionsThatGoOutOfBounds_ThenReturnOutOfBoundsAsTrue()
        {
            //Arrange
            var mockValidation = new Mock<IValidation>();
            var mockInputOutput = new Mock<IInputOutput>();
            var game = new Game(mockInputOutput.Object);

            var robot = SampleRobotWithInstruction();
            robot.Instructions = "MMMMMMMM";

            // Act
            var responseRobot = game.CommenceGame(SampleArena(), robot);

            //Assert
            responseRobot.OutOfBounds.ShouldBe(true);
        }

        private Robot SampleRobotWithInstruction()
        {
            return new Robot
            {
                X = 5,
                Y = 5,
                Orientation = Orientation.North,
                OutOfBounds = false
            };
        }

        private Arena SampleArena()
        {
            return new Arena
            {
                X = 9,
                Y = 9
            };
        }
    }
}
