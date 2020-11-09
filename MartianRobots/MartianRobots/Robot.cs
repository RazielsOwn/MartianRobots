namespace MartianRobots
{
    /// <summary>
    /// Robot class, for individual robot
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Current X coordinate
        /// </summary>
        public int CurrentX { get; set; }
        /// <summary>
        /// Current Y coordinate
        /// </summary>
        public int CurrentY { get; set; }
        /// <summary>
        /// Current Direction
        /// </summary>
        public RobotDirections CurrentDirection { get; set; }
        /// <summary>
        ///  Robot actions queue
        /// </summary>
        private readonly string actionsQueue;

        public Robot(int currentX, int currentY, string currentDirection, string actions)
        {
            CurrentX = currentX;
            CurrentY = currentY;

            // assume that north is direction by default or bad input value
            switch (currentDirection)
            {
                case "N":
                default:
                    CurrentDirection = RobotDirections.North;
                    break;
                case "S":
                    CurrentDirection = RobotDirections.South;
                    break;
                case "W":
                    CurrentDirection = RobotDirections.West;
                    break;
                case "E":
                    CurrentDirection = RobotDirections.East;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(actions))
            {
                actionsQueue = actions;
            }
        }

        /// <summary>
        /// Method for next robot action in Queue
        /// </summary>
        /// <returns>true if there is next action, false otherwise</returns>
        public bool NextAction()
        {
            return false;
        }
    }
}
