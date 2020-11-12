namespace MartianRobots
{
    public interface IField
    {
        /// <summary>
        /// Check if moving is available for selected direction
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns>false - if robot will be lost</returns>
        bool IsMovementAvailable(int currentX, int currentY, RobotDirections direction);

        /// <summary>
        /// Check if moving is forbidden based on previous robots data (marked squares)
        /// </summary>
        /// <param name="currentX"></param>
        /// <param name="currentY"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        bool IsMovementForbidden(int currentX, int currentY, RobotDirections direction);
    }
}