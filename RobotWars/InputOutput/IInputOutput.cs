using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public interface IInputOutput
    {
        void InputRobotInstructionsText(int robotNum);
        void InputRobotPositionText(int robotNum);
        void IntroductionText();
        void OutOfBoundsText();
        string InputRobotInstructions();
        Robot InputRobotPosition(Arena arena);
        Arena InputArenaCoordinates();
        Arena InputArena();
        void OutputSummary(Robot[] robots);
    }
}
