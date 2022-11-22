using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public interface IRobot
    {
        int X { get; set; }
        int Y { get; set; }
        Orientation Orientation { get; set; }
        string Instructions { get; set; }
        string FinalPosition { get; set; }
        bool OutOfBounds { get; set; }
        Robot AddRobot(int robotNum, Arena arena);
        Robot[] InitializeRobotsAndGame(Arena arena);
    }
}
