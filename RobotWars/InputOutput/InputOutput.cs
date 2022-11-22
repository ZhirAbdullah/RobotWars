using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using RobotWars;

namespace RobotWars
{
    public class InputOutput : IInputOutput
    {
        private IValidation _validation;
        public InputOutput(IValidation validation)
        {
            _validation = validation;
        }
        public void IntroductionText()
        {
            StringBuilder introText = new StringBuilder();
            introText.AppendLine("Welcome to Robot Wars!");
            introText.AppendLine("In order for our robots to commence battle, we need to set the size of the arena.");
            Console.WriteLine(introText.ToString());
        }

        public void InputRobotPositionText(int robotNum)
        {
            switch (robotNum)
            {
                case 1:
                    Console.WriteLine($"Please Enter the coordinates and orientation of the First Robot:");
                    break;
                case 2:
                    Console.WriteLine($"Please Enter the coordinates and orientation of the Second Robot");
                    break;
                default:
                    break;
            }
        }

        public void InputRobotInstructionsText(int robotNum)
        {
            switch (robotNum)
            {
                case 1:
                    Console.WriteLine($"Please Enter the instructions for the First Robot:");
                    break;
                case 2:
                    Console.WriteLine($"Please Enter the instructions for the Second Robot:");
                    break;
                default:
                    break;
            }
        }

        public Robot InputRobotPosition(Arena arena)
        {
            bool robotValid;
            string input = "";
            do
            {
                Console.WriteLine($"Please type in the input in this format (Example: 12N) and make sure it is within the arena (0,0) to ({arena.X},{arena.Y})");
                input = Console.ReadLine().ToUpper();
                robotValid = _validation.ValidateRobotPosition(input, arena);
            }
            while (!robotValid);

            int x = Convert.ToInt32(input[0].ToString());
            int y = Convert.ToInt32(input[1].ToString());
            Orientation orientation = SetOrientation(input[2].ToString());

            return new Robot() { X = x, Y = y, Orientation = orientation };
        }

        public Orientation SetOrientation(string direction)
        {
            switch (direction)
            {
                case "N":
                    return Orientation.North;
                case "E":
                    return Orientation.East;
                case "S":
                    return Orientation.South;
                default:
                    return Orientation.West;
            }
        }

        public string InputRobotInstructions()
        {
            bool instructionsValid;
            string input = "";
            do
            {
                Console.WriteLine("Please type in the instructions, the valid inputs are L,R,M");
                input = Console.ReadLine().ToUpper();
                instructionsValid = _validation.ValidateRobotInstructions(input);
            }
            while (!instructionsValid);

            return input;
        }

        public Arena InputArenaCoordinates()
        {
            Console.WriteLine("Please type below, the maximum width (x-Coordinates) and maximum length (y-Coordinates) of the arena.");
            Arena arenaSize = InputArena();
            Console.WriteLine($"you have chosen coordinates ({arenaSize.X},{arenaSize.Y}) as the maximum size of the arena");

            return arenaSize;
        }

        public Arena InputArena()
        {
            bool arenaValid;
            string input = "";
            do
            {
                Console.WriteLine("Please make sure to input 2 integers (Example: 55)");
                input = Console.ReadLine();
                arenaValid = _validation.ValidateArenaSize(input);
            }
            while (!arenaValid);

            int x = Convert.ToInt32(input[0].ToString());
            int y = Convert.ToInt32(input[1].ToString());

            return new Arena() { X = x, Y = y };
        }

        public void OutOfBoundsText() => Console.WriteLine("Robot is out of bounds!");

        public void OutputSummary(Robot[] robots)
        {
            Console.WriteLine("Here are the final Robot Positons:");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(OutputRobotPositions(robots[i], i + 1));
            }
        }

        public string OutputRobotPositions(Robot robot, int robotNumber)
        {
            if (robot.OutOfBounds)
                return $"Robot {robotNumber} is out of bounds";
            else
                return robot.FinalPosition;
        }

    }
}
