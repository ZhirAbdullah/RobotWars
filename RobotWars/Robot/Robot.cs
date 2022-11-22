using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RobotWars;

namespace RobotWars
{
    public class Robot : IRobot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation Orientation { get; set; }
        public string Instructions { get; set; }
        public string FinalPosition { get; set; }
        public bool OutOfBounds { get; set; }

        private IInputOutput _inputOutput;
        private IGame _game;
        public Robot(IInputOutput inputOutput, IGame game)
        {
            _inputOutput = inputOutput;
            _game = game;
        }
        public Robot() { }

        public Robot[] InitializeRobotsAndGame(Arena arena)
        {
            List<Robot> robotList = new List<Robot>(); 
            // Max 2 robots
            for (int i = 1; i < 3; i++)
            {
                Robot robot = AddRobot(i, arena);
                robot = _game.CommenceGame(arena, robot);
                robotList.Add(robot);
            }
            return robotList.ToArray();
        }

        public Robot AddRobot(int robotNum, Arena arena)
        {
            Robot robot = InitializeRobotPosition(robotNum, arena);
            robot.Instructions = InitializeRobotInstructions(robotNum, robot);
            return robot;
        }

        private Robot InitializeRobotPosition(int robotNum, Arena arena)
        {
            _inputOutput.InputRobotPositionText(robotNum);
            return _inputOutput.InputRobotPosition(arena);
        }

        private string InitializeRobotInstructions(int robotNum, Robot robot)
        {
            _inputOutput.InputRobotInstructionsText(robotNum);
            return _inputOutput.InputRobotInstructions();
        }
    }

    public enum Orientation
    {
        North,
        East,
        South,
        West
    }
}
