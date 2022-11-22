using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RobotWars
{
    public class Validation : IValidation
    {
        public bool ValidateArenaSize(string value)
        {
            return !string.IsNullOrEmpty(value) && IsNumeric(value) && IsCorrectSize(value, 2);
        }

        public bool ValidateRobotPosition(string value, Arena arena)
        {
            return !string.IsNullOrEmpty(value) && IsCorrectSize(value, 3) && IsRobotPositionCorrrectFormat(value) 
                && DoesOrientationMatch(value) && IsWithinArena(value, arena);
        }

        public bool ValidateRobotInstructions(string value)
        {
            return !string.IsNullOrEmpty(value) && CheckInstructionsValid(value);
        }

        public bool ValidateNewRobotPosition(Arena arena, Robot robot)
        {
            return CheckWithinArena(arena, robot);
        }

        private bool CheckInstructionsValid(string value)
        {
            string[] validInputs = new[] { "L", "R", "M" };
            for (int i = 0; i < value.Length; i++)
            {
                if (!validInputs.Contains(value[i].ToString()))
                    return false;
            }
            return true;
        }

        public bool IsRobotPositionCorrrectFormat(string value)
        {
            var regexCheck = new Regex("^\\d{2}[A-Za-z]{1}$");
            return regexCheck.IsMatch(value);
        }

        private bool DoesOrientationMatch(string value)
        {
            string[] orientationList = new[] { "N", "E", "S", "W" };
            return orientationList.Any(x => value.EndsWith(x));
        }

        private bool IsNumeric(string value)
        {
            return int.TryParse(value, out int n);
        }

        private bool IsCorrectSize(string value, int requiredLength)
        {
            return value.Length == requiredLength;
        }

        private bool IsWithinArena(string value, Arena arena)
        {
            var xInput = Convert.ToInt32(value.Substring(0, 1));
            var yInput = Convert.ToInt32(value.Substring(1, 1));

            return CheckWithinArena(arena, new Robot() {X = xInput, Y = yInput });
        }

        public bool CheckWithinArena(Arena arena, Robot robot)
        {
            return robot.X <= arena.X && robot.Y <= arena.Y && robot.X >= 0 && robot.Y >= 0;
        }
    }
}
