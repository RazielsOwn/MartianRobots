using System.Collections.Generic;

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
        private readonly Queue<char> actionsQueue;

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

            actions = actions.ToUpper();
            if (!string.IsNullOrWhiteSpace(actions))
            {
                for (var i = 0; i < actions.Length; i++)
                {
                    actionsQueue.Enqueue(actions[i]);
                }
            }
        }

        /// <summary>
        /// Method for next robot action in Queue
        /// </summary>
        /// <returns>true if there is next action, false otherwise</returns>
        public bool NextAction()
        {
            while (true)
            {
                // break on empty queue
                if (actionsQueue.Count == 0)
                {
                    break;
                }

                var nextAction = actionsQueue.Dequeue();
                // check if action is valid
                switch (nextAction)
                {
                    // turn left
                    case 'L':
                        CurrentDirection = CurrentDirection.Previous();
                        return true;
                    // turn right
                    case 'R':
                        CurrentDirection = CurrentDirection.Next();
                        return true;
                    // move forward
                    case 'F':
                        moveForward();
                        return true;
                        // additional actions
                }
            }
            return false;
        }

        // move forward current direction
        private void moveForward()
        {
            switch (CurrentDirection)
            {
                case RobotDirections.North:
                    CurrentY++;
                    break;
                case RobotDirections.South:
                    CurrentY--;
                    break;
                case RobotDirections.West:
                    CurrentX--;
                    break;
                case RobotDirections.East:
                    CurrentX++;
                    break;
            }
        }
    }
}
