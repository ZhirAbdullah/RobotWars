using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars
{
    public interface IGame
    {
        Robot CommenceGame(Arena arena, Robot robot);
    }
}
