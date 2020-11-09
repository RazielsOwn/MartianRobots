using System.Collections.Generic;

namespace MartianRobots
{
    public interface IField
    {
        int MaximumX { get; set; }
        int MaximumY { get; set; }

        /// <summary>
        /// Check if moving is available for selected direction
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns>false - if robot will be lost, null - if this direction is forbidden based on previous robots data (marked squares) </returns>
        bool? CanMoveToDirection(int currentX, int currentY, RobotDirections direction);
    }
}