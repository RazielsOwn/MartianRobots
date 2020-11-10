using MartianRobots.Core.RobotActions;
using System.Collections.Generic;

namespace MartianRobots
{
    /// <summary>
    /// Robot class, for individual robot
    /// </summary>
    public class Robot : IRobot
    {
        private readonly IField currentField;
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
            CurrentX = currentX < 0 ? 0 : currentX;
            CurrentY = currentY < 0 ? 0 : currentY;

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

            if (!string.IsNullOrWhiteSpace(actions))
            {
                actions = actions.ToUpper();
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

                //var nextAction = actionsQueue.Dequeue();

                var nextAction = ActionStrategyFabric.GetAction(actionsQueue.Dequeue());
                if (nextAction == null)
                {
                    // log or throw exception
                    return false;
                }

                if (!nextAction.DoAction(currentField, this))
                {
                    // robot will be lost so just stop further execution
                    return false;
                }

                continue;
            }
        }
    }
}
