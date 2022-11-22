using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Game : IGame
    {
        private IInputOutput _inputOutput;
        public Game(IInputOutput inputOutput)
        {
            _inputOutput = inputOutput;
        }
        public Robot CommenceGame(Arena arena, Robot robot)
        {
            foreach (char instruction in robot.Instructions)
            {
                robot = ApplyInstruction(robot, instruction);
            }
            Validation validation = new Validation();
            if (validation.ValidateNewRobotPosition(arena, robot))
            {
                robot.FinalPosition = RobotFinalPosition(robot);
            }
            else
            {
                robot.OutOfBounds = true;
                _inputOutput.OutOfBoundsText();
            }
            return robot;
        }

        public string RobotFinalPosition(Robot robot)
        {
            StringBuilder finalPosition = new StringBuilder();
            finalPosition.Append(robot.X);
            finalPosition.Append(robot.Y);
            finalPosition.Append(SetReverseOrientation(robot.Orientation));
            return finalPosition.ToString();
        }

        public string SetReverseOrientation(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.North:
                    return "N";
                case Orientation.East:
                    return "E";
                case Orientation.South:
                    return "S";
                default:
                    return "W";
            }
        }

        private Robot ApplyInstruction(Robot robot, char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    robot.Orientation = TurnLeft(robot);
                    break;
                case 'R':
                    robot.Orientation = TurnRight(robot);
                    break;
                default:
                    // M
                    robot = MoveForward(robot);
                    break;
            }
            return robot;
        }

        private Orientation TurnLeft(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    return Orientation.West;
                case Orientation.West:
                    return Orientation.South;
                case Orientation.South:
                    return Orientation.East;
                default:
                    return Orientation.North;
            }
        }

        private Orientation TurnRight(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    return Orientation.East;
                case Orientation.East:
                    return Orientation.South;
                case Orientation.South:
                    return Orientation.West;
                default:
                    return Orientation.North;
            }
        }

        private Robot MoveForward(Robot robot)
        {
            switch (robot.Orientation)
            {
                case Orientation.North:
                    robot.Y++;
                    break;
                case Orientation.East:
                    robot.X++;
                    break;
                case Orientation.South:
                    robot.Y--;
                    break;
                default:
                    // West
                    robot.X--;
                    break;
            }
            return robot;
        }
    }
}
