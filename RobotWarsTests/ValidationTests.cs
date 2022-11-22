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
    public class ValidationTests
    {
        [Fact]
        public void GivenCorrectArenaInput_ThenValidateAsTrue()
        {
            // Arrange
            var validation = new Validation();
            // Act
            var response = validation.ValidateArenaSize("99");

            //Assert
            response.ShouldBe(true);
        }
        [Fact]
        public void GivenNonNumericArenaInput_ThenValidateAsFalse()
        {
            // Arrange
            var validation = new Validation();
            // Act
            var response = validation.ValidateArenaSize("GG");

            //Assert
            response.ShouldBe(false);
        }

        [Fact]
        public void GivenLengthyArenaInput_ThenValidateAsFalse()
        {
            // Arrange
            var validation = new Validation();
            // Act
            var response = validation.ValidateArenaSize("1010");

            //Assert
            response.ShouldBe(false);
        }

        [Fact]
        public void GivenRobotPositionMatchesRegex_ThenValidateAsTrue()
        {
            // Arrange
            var validation = new Validation();
            // Act
            var response = validation.IsRobotPositionCorrrectFormat("34N");

            //Assert
            response.ShouldBe(true);
        }

        [Fact]
        public void GivenRobotPositionOutOfBounds_ThenValidateAsFalse()
        {
            // Arrange
            var validation = new Validation();
            // Act         
            var response = validation.CheckWithinArena(SampleArena(), SampleOutOfBoundsRobot());

            //Assert
            response.ShouldBe(false);
        }

        [Fact]
        public void GivenCorrectRobotInstruction_ThenValidateAsTrue()
        {
            // Arrange
            var validation = new Validation();
            // Act         
            var response = validation.ValidateRobotInstructions("LLMMRM");

            //Assert
            response.ShouldBe(true);
        }

        [Fact]
        public void GivenIncorrectRobotInstruction_ThenValidateAsFalse()
        {
            // Arrange
            var validation = new Validation();
            // Act         
            var response = validation.ValidateRobotInstructions("LLMMRMS");

            //Assert
            response.ShouldBe(false);
        }

        private Robot SampleOutOfBoundsRobot()
        {
            return new Robot
            {
                X = 10,
                Y = 10
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
