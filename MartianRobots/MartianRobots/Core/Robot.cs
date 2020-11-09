using System.Collections.Generic;

namespace MartianRobots
{
    /// <summary>
    /// Robot class, for individual robot
    /// </summary>
    public class Robot : IRobot
    {
        private IField currentField;
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

        public Robot(IField field, int currentX, int currentY, string currentDirection, string actions)
        {
            actionsQueue = new Queue<char>();
            currentField = field;
            CurrentX = currentX;
            CurrentY = currentY;

            // assume that north is direction by default or bad input value
            switch (currentDirection.ToUpper())
            {
                case "N":
                default:
                    CurrentDirection = RobotDirections.N;
                    break;
                case "S":
                    CurrentDirection = RobotDirections.S;
                    break;
                case "W":
                    CurrentDirection = RobotDirections.W;
                    break;
                case "E":
                    CurrentDirection = RobotDirections.E;
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
        /// <returns>true - if all is alright, false - if robot lost</returns>
        public bool ExecuteActions()
        {
            while (true)
            {
                // break on empty queue
                if (actionsQueue.Count == 0)
                {
                    return true;
                }

                var nextAction = actionsQueue.Dequeue();
                // check if action is valid
                switch (nextAction)
                {
                    // turn left
                    case 'L':
                        CurrentDirection = CurrentDirection.Previous();
                        continue;
                    // turn right
                    case 'R':
                        CurrentDirection = CurrentDirection.Next();
                        continue;
                    // move forward
                    case 'F':
                        var canMove = currentField.CanMoveToDirection(CurrentX, CurrentY, CurrentDirection);
                        if (canMove == null)
                        {
                            // direction forbidden so skip action
                            continue;
                        }

                        if (!canMove.Value)
                        {
                            // robot will be lost so just stop further execution
                            return false;
                        }

                        moveForward();
                        // additional actions
                        continue;
                }
            }
        }

        // move forward current direction
        private void moveForward()
        {
            switch (CurrentDirection)
            {
                case RobotDirections.N:
                    CurrentY++;
                    break;
                case RobotDirections.S:
                    CurrentY--;
                    break;
                case RobotDirections.W:
                    CurrentX--;
                    break;
                case RobotDirections.E:
                    CurrentX++;
                    break;
            }
        }
    }
}
