using RobotWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Application
    {
        private IRobot _robot;
        private IInputOutput _inputOutput;
        public Application(IRobot robot, IInputOutput inputOutput)
        {
            _robot = robot;
            _inputOutput = inputOutput;

            InitializeRobotWars();
        }
        public void InitializeRobotWars()
        {
            _inputOutput.IntroductionText();

            Arena arena = _inputOutput.InputArenaCoordinates();

            Robot[] robots = _robot.InitializeRobotsAndGame(arena);

            _inputOutput.OutputSummary(robots);
        }

    }
}
