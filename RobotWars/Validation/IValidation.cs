using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public interface IValidation
    {
        bool ValidateArenaSize(string value);
        bool ValidateRobotPosition(string value, Arena arena);
        bool ValidateRobotInstructions(string value);
        bool ValidateNewRobotPosition(Arena arena, Robot robot);
    }
}
